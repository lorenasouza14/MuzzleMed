using StackExchange.Redis;
using MuzzleMedBackend.Domain.Contexts.BookTime.Interfaces;


namespace MuzzleMedBackend.Infrastructure.Contexts.BookTime.Repository
{
    public class BookTimeRepository : IBookTimeRepository

    {
        private readonly IDatabase _redisDb;

        public BookTimeRepository(IConnectionMultiplexer redis)
        {
            _redisDb = redis.GetDatabase();
        }


        public async Task<List<string>> GetBookedTimesByDate(string dateSchedule)
        {
            if (string.IsNullOrEmpty(dateSchedule))
            {
                return new List<string>();
            }

            var bookedTimes = new List<string>();

            // Variavel de busca
            string searchPattern = $"book_time:{dateSchedule}:*";

            try
            {
                // Conecta com o servidor Redis
                var endpoint = _redisDb.Multiplexer.GetEndPoints().First();
                var server = _redisDb.Multiplexer.GetServer(endpoint);

                //Busca
                await foreach (var key in server.KeysAsync(pattern: searchPattern))
                {
                    string keyStr = key.ToString();


                    // Recorta a string para voltar somente o horario 
                    var parts = keyStr.Split(':');

                    if (parts.Length >= 3)
                    {
                        string timePart = parts[2];
                        bookedTimes.Add(timePart);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao consultar os horários agendados no servidor.");
            }

                return bookedTimes;
        }


        public async Task ReleaseBookTime(Guid userId, string dateSchedule, string timeSchedule)
        {
            string timeKey = $"book_time:{dateSchedule}:{timeSchedule}";
            string userKey = $"user_lock:{userId}";

            // Deleta as duas chaves do Redis se concluir o agendamento
            await _redisDb.KeyDeleteAsync(timeKey);
            await _redisDb.KeyDeleteAsync(userKey);
        }

        public async Task<bool> RegisterBookTime(Guid userId, string dateSchedule, string timeSchedule)
        {
            try
            {
                // Armazena os dois tipos de chaves para facilitar a busca
                string timeKey = $"book_time:{dateSchedule}:{timeSchedule}";
                string userKey = $"user_lock:{userId}";

                string redisValue = userId.ToString();
                string timeValue = $"{dateSchedule}:{timeSchedule}";

                // Bloqueia o horário caso alguém já tenha reservado (Trava do Horário)
                bool timeLocked = await _redisDb.StringSetAsync(timeKey, redisValue, TimeSpan.FromMinutes(10), When.NotExists);
                if (!timeLocked) return false;

                // Verifica se o usuário já possui alguma reserva antiga pendente (Trava do Usuário)
                RedisValue oldTimeValue = await _redisDb.StringGetAsync(userKey);

                if (oldTimeValue.HasValue && !oldTimeValue.IsNullOrEmpty)
                {
                    // Conversão para string 
                    string oldTimeKey = $"book_time:{oldTimeValue.ToString()}";

                    // Deleta a reserva antiga se ele escolher outro horário
                    await _redisDb.KeyDeleteAsync(oldTimeKey);
                }

                // Atualiza a trava do usuário com o novo horário. Também expira em 10 min
                await _redisDb.StringSetAsync(userKey, timeValue, TimeSpan.FromMinutes(10));

                return true;
            }
            catch (RedisConnectionException ex)
            {
                // Erro de comunicação com o Redis
                throw new Exception("Não foi possível conectar ao servidor Redis. Verifique se ele está rodando.", ex);
            }
            catch (Exception ex)
            {
                // Outros erros 
                throw new Exception($"Erro interno ao registrar agendamento: {ex.Message}", ex);
            }
        }

        /*
         EXemplo:
             "book_time:2026-06-25:14:00" | "UserId1"
             "user_lock:UserId1" | "2026-06-25:14:00"
         */
    }
}


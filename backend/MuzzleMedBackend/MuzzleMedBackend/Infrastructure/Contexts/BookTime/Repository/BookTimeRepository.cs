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
            //Armaza os dois tipos de chaves para facilitar a busca
            string timeKey = $"book_time:{dateSchedule}:{timeSchedule}";
            string userKey = $"user_lock:{userId}";

            string redisValue = userId.ToString();
            string timeValue = $"{dateSchedule}:{timeSchedule}";

            // Bloqueia o horario caso alguem tenha reservado.
            bool timeLocked = await _redisDb.StringSetAsync(timeKey, redisValue, TimeSpan.FromMinutes(10), When.NotExists);
            if (!timeLocked) return false;

           
            // Verifica se o usuario ja possui algum horario salvo
            var oldTimeValue = await _redisDb.StringGetAsync(userKey);

            if (oldTimeValue.HasValue){
                string oldTimeKey = $"book_time:{oldTimeValue}";

                // Deletamos a reserva se ele clicar em outro horario e o antigo ficara livre
                await _redisDb.KeyDeleteAsync(oldTimeKey);
            }
           
            // atualiza o novo horario do usuario para ser reservado. Ela tambem ira expirar em 10 min
            await _redisDb.StringSetAsync(userKey, timeValue, TimeSpan.FromMinutes(10));

            return true;
        }

        /*
         EXemplo:
             "book_time:2026-06-25:14:00" | "UserId1"
             "user_lock:UserId1" | "2026-06-25:14:00"
         */
    }
}


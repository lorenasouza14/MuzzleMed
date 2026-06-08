# MuzzleMed

> Um sistema para agendamento de consultas veterinárias, construído com foco no alinhamento entre as regras de negócio utilizando DDD e a arquitetura de software.

## Sobre o Projeto

O **MuzzleMed** permite que tutores gerenciem seus pets, escolham clínicas e veterinários de sua preferência, possam agendar consultas e manter um histórico de diagnósticos. 
Para garantir a escalabilidade e a manutenção a longo prazo, o projeto foi desenhado utilizando **Domain-Driven Design (DDD)** e **Clean Architecture**.

## Bounded Contexts (Mapeamento do Domínio)
* **Auth:** Responsável pela segurança, controle de acesso e emissão de JWT.
* **Profile:** Gestão das informações de usuários (tutores) e seus respectivos pets.
* **BookTime / Schedule:** O coração do negócio. Gerencia as reservas, horários disponíveis de veterinários e clínicas.

## Regras de Negócio (Core)
- **Unicidade:** O CPF dos usuários deve ser único no sistema.
- **Consistência de Agenda:** É impossível agendar duas consultas no mesmo dia e horário para o mesmo recurso.
- **Dependência Estrutural:** Uma consulta válida exige a relação completa entre: Pet + Usuário + Clínica + Veterinário.
- **Proteção de Dados:** Um pet com consultas ativas ou agendadas não pode ser removido do sistema.
- **Segurança:** Rotas e informações sensíveis exigem autenticação ativa.


## Arquitetura do Projeto
O repositório está organizado em formato *monorepo* (backend e frontend num mesmo repositório), separando o cliente e o servidor:


```text
Backend/
MuzzleMedBackend/
├── API/
│   └── Controllers/
├── Core/
│   └── Contexts/
│       ├── Auth/
│       ├── BookTime/
│       ├── Profile/
│       └── Schedule/
├── Domain/
│   └── Contexts/
│       ├── Auth/
│       │   ├── Entities/
│       │   ├── Interfaces/
│       │   └── ValueObjects/
│       ├── BookTime/
│       ├── Profile/
│       └── Schedule/
├── Infrastructure/
│   └── Contexts/
│       ├── Auth/
│       │   ├── Persistence/
│       │   └── Repositories/
│       ├── BookTime/
│       ├── Profile/
│       └── Schedule/
├── Migrations/
├── Properties/
├── Services/
└── Configurações: .env, .gitignore, appsettings.json, docker-compose.yml, MuzzleMedBackend.http
```

```text
Frontend/
├── src/
│   ├── Assets/
│   ├── Components/
│   ├── Pages/
│   ├── Services/
│   └── Styles/
└── Configurações: .gitignore, vite.config.js, package.json, index.html         
```


## Tecnologias e Ferramentas

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
![Redis](https://img.shields.io/badge/Redis-DC382D?style=for-the-badge&logo=redis&logoColor=white)
![React](https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)
![Vite](https://img.shields.io/badge/Vite-646CFF?style=for-the-badge&logo=vite&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)



## Como Executar o Projeto 
**Pré-requisitos:**
Certifique-se de ter instalado em sua máquina o
[Docker](https://www.docker.com/), [.NET SDK](https://dotnet.microsoft.com/) e [Node.js](https://nodejs.org/) 



### Passo a Passo para a execução:

1. Clone o repositório:
   ```bash
   git clone https://github.com/lorenasouza14/MuzzleMed.git
2. Entre na pasta do backend e crie o seu arquivo .env baseado no exemplo (preencha com as credenciais do banco)

3. Suba os containers do Docker,
certifique-se de que o aplicativo do Docker Desktop está ativo e, ainda na pasta do backend, execute:
    ```bash
    docker compose up -d
4. Crie as tabelas no banco de dados com o comando:
    ```bash
    dotnet ef database update
5. Execute a API C#:
    ```bash
    dotnet run
6. Para subir a aplicação do frontend abra um novo terminal, navegue até a pasta do frontend e execute os comandos:
    ```bash
    npm install
    npm run dev
7. Acesse a aplicação através da URL informada no terminal do seu frontend (geralmente http://localhost:5173).


## Desenvolvido por:

[Heloísa Ribeiro](https://github.com/hribes) • [Paola Bíscaro](https://github.com/PaolaBiscaro) • [Lucas Hygidio](https://github.com/LucasHygidio) • [Lorena de Souza](https://github.com/lorenasouza14)•




## Agradecimento e Feedback

Obrigado por visitar o nosso projeto! O **MuzzleMed** foi um grande aprendizado para toda a equipe. 
Se você tiver alguma sugestão de melhoria, crítica construtiva ou quiser trocar uma ideia sobre a arquitetura utilizada, sinta-se à vontade para abrir uma *Issue* ou entrar em contato com qualquer um dos desenvolvedores!



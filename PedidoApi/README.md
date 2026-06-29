# PedidoApi

API RESTful para gerenciamento de pedidos e usuários, construída com ASP.NET Core 8 e Entity Framework Core.

## Stack

| Tecnologia | Versão |
|---|---|
| .NET | 8.0 |
| ASP.NET Core | 8.0 |
| Entity Framework Core | 8.0.17 |
| SQL Server | 8.0.17 |
| MediatR | 14.1.0 |
| JWT Bearer | 8.0.17 |
| Swashbuckle | 6.6.2 |
| xUnit | 2.5.3 |
| Moq | 4.20.72 |
| FluentAssertions | 8.10.0 |

## Estrutura (Clean Architecture)

```
PedidoApi/
├── API/                    # Camada de apresentação
│   ├── Controllers/        # AuthController, UsersController, OrdersController
│   └── Middleware/         # RequestLogMiddleware
├── Application/            # Casos de uso (CQRS)
│   ├── Commands/           # CreateUserCommand + Handler
│   ├── Queries/            # GetUserByIdQuery + Handler
│   └── Services/           # UserService
├── Domain/                 # Entidades e contratos
│   ├── Entities/           # User, Order
│   └── Repositories/       # IUserRepository
├── Infrastructure/         # Persistência e implementações
│   ├── Persistence/        # AppDbContext
│   └── Repositories/       # UserRepository
└── Migrations/             # EF Core Migrations
```

## Pré-requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (local ou remoto)
- dotnet-ef (ferramenta global)

```bash
dotnet tool install --global dotnet-ef
```

## Configuração

1. Edite `appsettings.json` com sua connection string:

```json
"ConnectionStrings": {
  "Default": "Server=localhost;Database=PedidoDb;User Id=sa;Password=123;TrustServerCertificate=True"
}
```

2. Configure a chave JWT em `appsettings.json` (opcional, já existe uma padrão):

```json
"Jwt": {
  "Key": "sua-chave-de-32-caracteres-aqui!",
  "Issuer": "PedidoApi",
  "Audience": "PedidoApi"
}
```

## Executando

```bash
# Restaurar pacotes
dotnet restore

# Criar/atualizar banco
dotnet ef database update

# Executar
dotnet run

# URL padrão: http://localhost:5202
# Swagger:     http://localhost:5202/swagger
```

## Autenticação

1. Faça login:

```bash
POST /auth/login
{
  "email": "admin@gmail.com",
  "password": "123"
}
```

2. Use o token retornado no header `Authorization: Bearer {token}`.

## Endpoints

### Auth
| Método | Rota | Descrição |
|---|---|---|
| POST | `/auth/login` | Autenticação JWT |

### Users (requer token)
| Método | Rota | Descrição |
|---|---|---|
| GET | `/users` | Listar todos |
| GET | `/users/{id}` | Buscar por ID |
| POST | `/users` | Criar usuário |

### Orders (requer token)
| Método | Rota | Descrição |
|---|---|---|
| GET | `/orders` | Listar todos (com User) |
| POST | `/orders` | Criar pedido |

## Testes

```bash
dotnet test
```

## Docker

```bash
docker build -t pedido-api .
docker run -p 8080:8080 pedido-api
```

## Licença

Projeto educacional.

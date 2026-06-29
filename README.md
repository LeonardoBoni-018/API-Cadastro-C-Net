# PedidoApi

API RESTful para gerenciamento de pedidos e usuários, construída com ASP.NET Core 8, Entity Framework Core e arquitetura limpa (Clean Architecture).

## Repositório

| Pasta | Descrição |
|---|---|
| [`PedidoApi/`](./PedidoApi) | Projeto principal da API |
| [`PedidoApi.Tests/`](./PedidoApi.Tests) | Projeto de testes unitários |

## Stack principal

- **.NET 8** / ASP.NET Core 8
- **Entity Framework Core 8** + SQL Server
- **MediatR** (CQRS)
- **JWT Bearer** (autenticação)
- **Swagger** (documentação)
- **xUnit** + **Moq** + **FluentAssertions** (testes)

## Como executar

```bash
# Acessar o projeto
cd PedidoApi

# Restaurar pacotes
dotnet restore

# Criar/atualizar banco
dotnet ef database update

# Executar
dotnet run

# Acessar: http://localhost:5202/swagger
```

## Testes

```bash
dotnet test
```

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
| GET | `/orders` | Listar todos |
| POST | `/orders` | Criar pedido |

## Docker

```bash
cd PedidoApi
docker build -t pedido-api .
docker run -p 8080:8080 pedido-api
```

---

Projeto educacional.

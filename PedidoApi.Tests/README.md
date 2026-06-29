# PedidoApi.Tests

Projeto de testes unitários da API PedidoApi.

## Stack

- **xUnit** (framework de testes)
- **Moq** (mocking)
- **FluentAssertions** (assertivas legíveis)

## Como executar

```bash
# Da raiz do repositório
dotnet test

# Ou diretamente desta pasta
dotnet test
```

## Testes existentes

| Teste | Descrição |
|---|---|
| `UserServiceTests.CreateAsync_ShouldReturnUser` | Verifica se `UserService.CreateAsync` retorna o usuário criado com os dados corretos |

## Estrutura

```
PedidoApi.Tests/
├── PedidoApi.Tests.csproj
├── UserServiceTests.cs
└── README.md
```

## Boas práticas utilizadas

- Mocks com Moq para isolar a camada de teste
- Assertivas com FluentAssertions para legibilidade
- Nomenclatura descritiva: `Método_DeveComportamentoEsperado`
- Testes assíncronos com `async Task`

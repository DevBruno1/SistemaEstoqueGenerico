# 📦 Sistema de Estoque Genérico (.NET)

Projeto desenvolvido em **C# / .NET** com o objetivo de praticar conceitos fundamentais de **arquitetura em camadas**, **boas práticas**, **testes automatizados** e **criação de APIs REST**, simulando um sistema simples de controle de estoque.

Este projeto faz parte do meu processo de aprendizado e preparação para minha **primeira oportunidade como desenvolvedor**.

---

## 🚀 Funcionalidades

- Entrada de produtos no estoque
- Saída de produtos com validações de estoque mínimo
- Transferência de produtos entre estoques
- Registro de movimentações de estoque
- Consulta de movimentações via API

---

## 🧱 Arquitetura do Projeto

O projeto foi organizado seguindo princípios de separação de responsabilidades:

- **Models** → Regras de negócio e domínio
- **DTOs** → Objetos de transferência de dados
- **Repositories** → Persistência em memória
- **Services** → Orquestração das regras de negócio
- **API** → Exposição das funcionalidades via HTTP (ASP.NET Core)
- **Tests** → Testes unitários com xUnit

---

## 🛠️ Tecnologias Utilizadas

- C#
- .NET 8
- ASP.NET Core Web API
- Swagger (OpenAPI)
- xUnit
- Injeção de Dependência
- Repositórios em memória

---

## ▶️ Como Executar o Projeto

### Pré-requisitos

- .NET SDK 8 ou superior

### Passos

```bash
git clone https://github.com/seu-usuario/SistemaEstoqueGenerico.git
cd SistemaEstoqueGenerico
dotnet run --project SistemaEstoqueGenerico.Api
```

http://localhost:5294/swagger

---

## 👤 Autor

**Bruno Ricardo Bastos**  
Estudante de Engenharia de Software  
Desenvolvedor em formação com foco em backend (.NET)

## 📌 Status do Projeto

🚧 Em evolução — novas funcionalidades e melhorias estão sendo adicionadas continuamente como parte do meu processo de aprendizado.

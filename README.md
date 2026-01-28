📦 Sistema de Estoque Genérico (.NET)

Projeto desenvolvido em C# / .NET com o objetivo de praticar e consolidar conceitos fundamentais de desenvolvimento backend, como arquitetura em camadas, regras de negócio, APIs REST e testes unitários, simulando um sistema simples de controle de estoque.

Este projeto faz parte do meu processo de aprendizado e preparação para minha primeira oportunidade como desenvolvedor.

---

🎯 Objetivo do Projeto

O objetivo deste projeto é aplicar, na prática, conceitos que são muito utilizados no mercado, como:

Separação de responsabilidades

Organização de código em camadas

Criação de APIs REST com ASP.NET Core

Implementação de regras de negócio no service

Uso de DTOs para entrada e saída de dados

Testes unitários focados na lógica de negócio

O sistema simula operações reais de um estoque, como entrada, saída e transferência de produtos, mantendo o histórico de movimentações.

---

🚀 Funcionalidades

📥 Entrada de produtos no estoque

📤 Saída de produtos com validações de quantidade

🔄 Transferência de produtos entre estoques

🧾 Registro de movimentações de estoque

🔍 Consulta de movimentações via API

📄 Documentação automática com Swagger

🧱 Arquitetura do Projeto

---

O projeto foi organizado seguindo princípios de arquitetura em camadas, facilitando manutenção, testes e evolução:

Models
Contêm as entidades e regras de domínio do sistema.

DTOs
Utilizados para transportar dados entre a API e a camada de serviço.

Repositories
Responsáveis pela persistência dos dados (atualmente em memória).

Services
Onde ficam as regras de negócio e validações.

API
Camada responsável por expor os endpoints HTTP utilizando ASP.NET Core.

Tests
Testes unitários focados na camada de serviço, utilizando xUnit.

---

🛠️ Tecnologias Utilizadas

C#

.NET 8

ASP.NET Core Web API

Swagger / OpenAPI

xUnit

Injeção de Dependência

Repositórios em memória

---

▶️ Como Executar o Projeto
Pré-requisitos

.NET SDK 8 ou superior

Passos
git clone https://github.com/DevBruno1/SistemaEstoqueGenerico.git
cd SistemaEstoqueGenerico
dotnet run --project SistemaEstoqueGenerico.Api

Acesse o Swagger em:

http://localhost:5294/swagger

---

🧪 Testes

Os testes unitários estão localizados no projeto:

SistemaEstoqueGenerico.Tests

Eles validam principalmente:

Regras de entrada e saída de estoque

Validações de quantidade

Comportamento da camada de serviço

---

📚 O que eu aprendi com este projeto

Estruturar um projeto backend em camadas

Aplicar regras de negócio de forma centralizada

Criar e consumir APIs REST

Trabalhar com DTOs

Utilizar injeção de dependência no .NET

Criar testes unitários para serviços

Documentar endpoints com Swagger

---

🔮 Próximos Passos

Adicionar persistência com banco de dados (ex: SQL Server)

Criar endpoints de consulta de estoque

Melhorar tratamento de erros da API

Evoluir a cobertura de testes

👤 Autor

Bruno Ricardo Bastos
Estudante de Engenharia de Software | Desenvolvedor em formação

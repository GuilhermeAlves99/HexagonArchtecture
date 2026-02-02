# Hexagonal Architecture – Insurance System

Este projeto foi desenvolvido como parte de um teste técnico, com o objetivo de demonstrar a aplicação de **Arquitetura Hexagonal (Ports & Adapters)**, **boas práticas de Clean Code**, **DDD**, **SOLID**, **Object Calisthenics** e uma abordagem baseada em **microserviços**.

O sistema simula uma **plataforma de seguros**, permitindo a criação, aprovação e contratação de propostas de seguro.

---

## Arquitetura

A solução está dividida em dois microserviços independentes, cada um com sua própria API, banco de dados e responsabilidades bem definidas.

### ProposalService
Responsável por:
- Criar propostas de seguro
- Consultar propostas
- Alterar status da proposta:
  - Em Análise
  - Aprovada
  - Rejeitada
- Expor API REST

### ContractService
Responsável por:
- Contratar uma proposta (somente se estiver **Aprovada**)
- Armazenar dados da contratação
- Consultar o ProposalService para validar o status da proposta
- Expor API REST

A comunicação entre os serviços ocorre via **HTTP (REST)**.

---

## Organização dos Projetos

Cada microserviço segue seu próprio fluxo sem compartilhar camadas arquitetural:

- **Core / Application**: Regras de negócio e casos de uso
- **Domain**: Entidades de domínio
- **Ports**: Contratos de entrada e saída
- **AdaptersOut**: Implementações concretas (EF Core, HTTP, etc.)
- **API**: Camada de exposição REST

---

## Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger
- Arquitetura Hexagonal (Ports & Adapters)

---

## Pré-requisitos

- .NET SDK 8+
- SQL Server (LocalDB ou SQL Server Express)
- Visual Studio 2022 ou superior

---

## Como Executar o Projeto

### Clone o repositório
```bash
git clone https://github.com/GuilhermeAlves99/HexagonArchtecture.git

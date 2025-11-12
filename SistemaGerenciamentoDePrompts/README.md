# ?? Projeto: Sistema de Gerenciamento de Prompts

API de microserviço para gerenciar prompts de IA, desenvolvida como parte da Global Solution (GS).

## ??? Tecnologias Utilizadas

* .NET 7 (ou a versão que estiver usando) Web API
* C#
* Dapper (Micro-ORM)
* SQLite (Banco de dados local)
* Swagger (Documentação de API)

## ?? Implementações Realizadas

Este projeto foi construído em várias etapas, rastreadas por branches.

### Etapa 1: Modelagem do Domínio
* **Branch:** `feature/modelagem-dominio`
* **Descrição:**
    * Criação do projeto Web API.
    * Definição da classe `Prompt` no namespace `SistemaGerenciamentoDePrompts.Models`.
    * Configuração da conexão com banco de dados (SQLite) e instalação do Dapper.
    * Script de teste no `Program.cs` para criar a tabela `Prompts` automaticamente na inicialização.

### Etapa 2: Implementação do Core
* **Branch:** `feature/implementacao-core`
* **Descrição:**
    * Criação da camada de Serviço (Interface `IPromptService` e classe `PromptService`).
    * Implementação dos métodos de CRUD (Create, ReadAll, ReadById) usando Dapper.
    * Configuração da Injeção de Dependência no `Program.cs` (`AddScoped`).
    * Criação do `PromptsController` com os endpoints `GET` (All/ById) e `POST` (Create).
    * Configuração do Swagger para documentação e teste da API.

### Etapa 3: Validações e Melhorias
* **Branch:** `feature/validacoes-e-melhorias`
* **Descrição:**
    * Implementação de tratamento de exceções (try-catch) nos endpoints do `PromptsController` para retornar erros `StatusCode 500` (Internal Server Error) de forma controlada.
    * Criação e atualização deste `README.md` com o descritivo de todas as etapas do projeto.
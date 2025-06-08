# SuperHeroAPI

Uma **API RESTful** desenvolvida em **.NET Core** usando **Entity Framework Core**, projetada para gerenciar um cadastro de super-heróis.  
Ela permite operações de **CRUD** (Create, Read, Update, Delete) em registros de super-heróis.

## 🚀 Tecnologias Utilizadas

- **.NET Core** (versão 8.0)
- **Entity Framework Core** (versão 9.0.5)
- **SQL Server**
- **Banco de dados InMemory**
- **Swagger** (para documentação e testes)

## 📦 Funcionalidades

A API expõe os seguintes endpoints para gerenciamento de super-heróis:

- **GET /api/heroes/list**  
  Retorna todos os super-heróis cadastrados.

- **GET /api/heroes/getById**  
  Retorna um super-herói específico pelo seu `id`.

- **POST /api/heroes/create**  
  Cria um novo super-herói.

- **PUT /api/heroes/update**  
  Atualiza os dados de um super-herói existente.

- **DELETE /api/superheroes/delete**  
  Remove um super-herói do cadastro.

- **GET /api/heroes/superpoderes**  
  Retorna todos os super poderes cadastrados.

## 🔧 Configuração e Execução
	
1️⃣ Configure a string de conexão com o banco de dados

No arquivo `appsettings.json`, configure a string de conexão para o seu banco de dados.


2️⃣ Crie o banco de dados e aplique as migrações

Use o comando `dotnet ef database update` no terminal para aplicar as migrações ao seu banco.

3️⃣ Execute a aplicação

Use o comando `dotnet run` no terminal para executar a aplicação.

## 🏗️ Estrutura do Projeto

```plaintext
MyHeroesAPI/
├── Controllers/
│   └── HeroesController.cs
├── Data/
│   └── AppDbContext.cs
├── Migrations/
├── Models/
│   └── Heroi.cs
├── MyHeroesUI/
├── Program.cs
├── appsettings.json
└── README.md

# Neoway - Technician Case

The purpose of this project is to show some of what I know.
The project consists of make a service that reads a file "base_teste.txt" and persist in a postgresql database.

## Technologies

- C# (Csharp)
- .Net Core
- Entity Framework Core
- PostgreSql

## Directory Structure

```
.
├── docker
│   └──dotnet
│      └──Dockerfile
├── source
│   ├── NeowayTechnicianCase.ConsoleApplication
│   │   ├── base_teste.txt
│   │   ├── Startup.cs
│   │   └── Program.cs
│   ├── NeowayTechnicianCase.Core
│   │   ├── Entities
│   │   └── Interfaces
│   │      ├── Repositores
│   │      ├── Services
│   │      └── Validations
│   └── NeowayTechnicianCase.Infrastructure
│       ├── Data
│       ├── Migrations
│       ├── Repositories
│       ├── Services
│       └── Validations
├── tests
│   ├── NeowayTechnicianCase.IntegrationTests
│   └── NeowayTechnicianCase.UnitTests
├── .dockerignore
├── .editorconfig
├── .gitignore
├── DER.png
├── docker-compose.yml
├── NeowayTechnicianCase.sln
└── README.md
```

## ERD - Entity Relationship Diagram

![alt text](https://github.com/ThallesTeodoro/NeowayTechnicianCase/blob/development/DER.png?raw=true)


## Setup

### Requirements

- Docker
- Docker Compose

> The application consuming the service is a Console Application. To see the terminal output you need first to up the database container, then run the application container. Follow the steps:

### Up Database Conteiner

```bash
docker-compose up -d database
```

### Run the project

```bash
docker-compose run dotnet --rm
```

---

After running the project, the application will prepare services (Database Connection, Repositories and Dependence Injection) and then call the services to read and persist the contents of the file "base_teste.txt" file and persist into database. You can see all the process on terminal.
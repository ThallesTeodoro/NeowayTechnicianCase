# Neoway - Technician Case

## Directory Structure

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

## DER

![alt text](https://github.com/ThallesTeodoro/NeowayTechnicianCase/blob/development/DER.jpg?raw=true)


## Setup

### Requirements

- Docker
- Docker Compose

### Up Database Conteiner

```bash
docker-compose up -d database
```

### Run the project

```bash
docker-compose run dotnet
```
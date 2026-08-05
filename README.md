![grupo-kyly](./images/logo.png)


# 🛍️ KyProduto - Sistema de Gerenciamento de Produtos

Aplicação Full Stack desenvolvida com **Angular** no frontend e **ASP.NET Core Web API** no backend para gerenciamento de produtos, utilizando autenticação baseada em **JWT (JSON Web Token)**.

O projeto demonstra a integração completa entre Front-end e Back-end, incluindo autenticação, autorização e consumo de uma API REST protegida.

---

# 📋 Sobre o projeto

O sistema permite que usuários autenticados consultem produtos através de uma interface intuitiva.

O fluxo da aplicação funciona da seguinte maneira:

1. O usuário realiza login.
2. A API valida as credenciais.
3. Um Token JWT é gerado.
4. O Angular armazena o token.
5. Um HTTP Interceptor adiciona automaticamente o token em todas as requisições protegidas.
6. O Auth Guard impede o acesso às páginas privadas caso o usuário não esteja autenticado.

---

# 🚀 Tecnologias utilizadas

## Backend

- ASP.NET Core
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger/OpenAPI

## Frontend

- Angular
- TypeScript
- Reactive Forms
- Angular Router
- HttpClient
- CSS3

---

# 🏗️ Arquitetura

```
Angular
│
├── Login
├── Auth Guard
├── HTTP Interceptor
├── Services
│
▼

ASP.NET Core Web API
│
├── Login
├── Produtos
├── JWT Authentication
│
▼

SQL Server
```

---

# 🔐 Autenticação

A autenticação utiliza **JWT (JSON Web Token)**.

Fluxo:

1. Usuário envia login e senha.
2. A API valida as credenciais.
3. Um Token JWT é gerado.
4. O Angular salva o token no navegador.
5. O HTTP Interceptor envia automaticamente:

```http
Authorization: Bearer <token>
```

para todos os endpoints protegidos.

---

# 🔍 Funcionalidades

## Login

- Autenticação com JWT
- Geração de Token
- Logout

## Produtos

- Pesquisa de produtos
- Consulta através da API REST
- Integração Angular + ASP.NET Core

## Segurança

- JWT Authentication
- Auth Guard
- HTTP Interceptor
- Rotas protegidas
- Endpoints protegidos

---

# 📁 Estrutura do projeto

```
Projeto
│
├── Backend/
│   ├── Controllers
│   ├── Models
│   ├── Services
│   ├── Data
│   └── Authentication
│
└── Frontend/
    └── src/
        └── app/
            ├── components/
            │     ├── search-box
            │     └── filter-panel
            │
            ├── core/
            │     ├── guards
            │     ├── interceptors
            │     └── services
            │
            ├── models/
            │
            ├── pages/
            │     ├── login
            │     └── home
            │
            └── services/
```

---

# ⚙️ Como executar

## Backend

```bash
git clone https://github.com/SEU_USUARIO/SEU_REPOSITORIO.git

cd Backend

dotnet restore

dotnet run
```

Swagger:

```
https://localhost:7020/swagger
```

---

## Frontend

```bash
cd Frontend

npm install

ng serve
```

Aplicação:

```
http://localhost:4200
```

---

# 📌 Endpoints

## Login

| Método | Endpoint |
|---------|----------|
| POST | /api/login |

## Produtos

| Método | Endpoint |
|---------|----------|
| GET | /api/produtos |
| GET | /api/produtos/{id} |
| POST | /api/produtos |
| PUT | /api/produtos/{id} |
| DELETE | /api/produtos/{id} |

> Todos os endpoints de Produtos exigem autenticação JWT.

---

# 📷 Telas

## Login

*Adicione um print da tela.*

## Pesquisa de Produtos

*Adicione um print da tela.*

## Swagger

*Adicione um print da documentação da API.*

---

# 🎯 Objetivos do projeto

Este projeto foi desenvolvido para praticar e demonstrar conhecimentos em:

- Desenvolvimento Full Stack
- ASP.NET Core Web API
- Angular
- Entity Framework Core
- APIs REST
- Arquitetura em Camadas
- Autenticação JWT
- Auth Guard
- HTTP Interceptor
- Consumo de APIs
- Boas práticas de organização de projetos

---


# 👨‍💻 Autor

**Lenilson Júnior**

- GitHub: https://github.com/LenilsonJr27
- LinkedIn: https://www.linkedin.com/in/lenilson-junior-540a5b22b/

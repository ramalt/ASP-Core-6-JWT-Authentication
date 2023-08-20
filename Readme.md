
# ASP.NET CORE JWT AUTHENTICATION

![](https://i.chzbgr.com/full/6518557440/h8C1CD7D0/halt-whats-de-password)

JWT authentication in .NET 6 Core with basic todo app.

## Features
- CRUD operation with todo routes.
- All the routes are has authentication policy.
- Login & register operations with JWT tokens.
- JWT refresh token feature for regenerating JWT tokens.

## Endpoints
- POST - /api/auth/register
- GET - /api/auth/login

### Protected
- GET    - /api/todo
- GET    - /api/todo/{id}
- PUT    - /api/todo/{id}
- POST   - /api/todo
- DELETE - /api/todo/{id}

## Tech Stack

### Asp.Net Core Identity
Identity package is has IdentityUser class and many use operations. So we use this package using for user create, user login validations etc. features.

### JWT Bearer
JWT tokens are provide various hashing algorithm to cryphting many user info's. We use **HMAC SHA256** algorithm to hashing payload have user credentials. Also we used IdentityDbContext of **Identity Package** . This feature provides token methods. 

And we have refresh token feature for token regenerating. This is important problem for token security.


### Entity Framework Core Sqlite

This project uses Sqlite tools because Sqlite is lightweight nosql database for minimal apps. We using lightweight database cause we **proof of API authentication.** 

Entity Framework powerful **Object Relation Mapping Tool** for managing our todo and Identity user tables on database. It is very simple to apply for another database. MongoDb, Microsoft SQL Server, PostgreSQL etc.

## Project

Project structure split the logic and bussines operations with service classes. All the logic operations places service class. And we use data table objects for specific response or fixed request schemas for clients.

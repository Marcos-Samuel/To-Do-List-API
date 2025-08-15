<table align="right">
  <tr>
    <td>
      <a href="README.md">🇧🇷 Português</a>
    </td>
  </tr>
</table>

![luk4x-repo-status](https://img.shields.io/badge/status-developing-lightgrey?style=for-the-badge&logo=headspace&logoColor=yellow&color=lightgrey)
![luk4x-repo-license](https://img.shields.io/github/license/Luk4x/apple-store?style=for-the-badge&logo=unlicense&logoColor=lightgrey)


# To-Do List API

API desenvolvida em **ASP.NET Core 8** para gerenciar tarefas, usuários e categorias de uma lista de afazeres. Utiliza **PostgreSQL** como banco de dados e JWT para autenticação.

## Funcionalidades

- CRUD de tarefas
- Autenticação via JWT
- Gerenciamento de usuários
- Categorias de tarefas
- Swagger para testes de API

## Tecnologias

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- JWT
- Swagger

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- Visual Studio 2022 ou VS Code

## Configuração do ambiente

1. Crie o banco de dados PostgreSQL:

```sql
CREATE DATABASE "to-do-list-api";
CREATE USER "postgres" WITH PASSWORD '123321Aa.';
GRANT ALL PRIVILEGES ON DATABASE "to-do-list-api" TO "postgres";
```
2. Configure as variáveis de ambiente (ou crie um arquivo .env):
```sql 
DATABASE_URL=Host=localhost;Port=5432;Database=to-do-list-api;Username=postgres;Password=123321Aa.
JWT_KEY=b7566de7d15a292a1c397a47d1080f8c0877f89f1d177c9127f6faf5bb598ce2
JWT_ISSUER=admin
JWT_AUDIENCE=teste-teste-teste
```

3. Executando o projeto localmente

Abra a solução no Visual Studio ou VS Code.

Restaure os pacotes NuGet:
```sql 
dotnet restore
````

4. Execute o projeto
```sql 
dotnet run --project "To-Do List-API/To-Do List-API.csproj"
```

5. Acesse o Swagger para testar a API: 
```sql 
https://localhost:5080/swagger/index.html
ou 
https://localhost:7021/swagger/index.html
````
Estrutura do projeto
```sql 
To-Do List-API/
├── Controllers/
├── Dtos/
├── Entities/
├── Services/
├── Context/
├── appsettings.json
├── Program.cs
└── To-Do List-API.csproj
```
## 🧙‍♀️ Autor

 <a href="https://www.linkedin.com/in/marcos-samuel-batista-m/">
 <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/121835618?v=4" width="100px;" alt=""/>
 <br />
 <sub><b>Marcos Samuel</b></sub></a>✨</a>
 <br />
---

## 📝 Licença

Feito por:
<br/>
Marcos Samuel [LinkedIn](https://www.linkedin.com/in/marcos-samuel-batista-m/)
<br/>

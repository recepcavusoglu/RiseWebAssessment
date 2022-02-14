# RiseWebAssessment
## _Rest API for Rise Assessment_


This is a REST API on .Net Core 6 for Rise Technology Back-End Assessment.

- .Net Core 6 : All codebase developed using .Net Core 6 and EF Core
- PostgreSQL : Used for main data storage
- Redis : Used for storing high cost query results for a period of time. With reportID users can get old query results.


### Directory layout

    ├── Controllers             # Controllers
    ├── Core                    # Project Wide Files
    ├── Data                    # Database Repository
    ├── Migrations              # Database Migrations Files created by .net
    ├── Model                   # Data Models
        ├── DTO                 # DTO Models
        ├── Entities            # Entity Models
    ├── Service                 # Service
        ├── ServiceAbstracts    # Service Interfaces
        ├── ServiceConcretes    # Service Implementations
    └── appsettings.json        # Config File

## Database Migration

To Migrate Database on Postgres

```sh
cd .\RiseWebAssessment
dotnet ef migrations add CreateInitial
dotnet ef database update
```

## NuGet Packages

All the necessary NuGet packages listed below.

| Package Name | Version |
| ------ | ------ |
| AutoMapper.Extensions.Microsoft.DependencyInjection | 11.0.0 |
| Microsoft.EntityFrameworkCore | 6.0.2 |
| Microsoft.EntityFrameworkCore.Design | 6.0.2 |
| Microsoft.Extensions.Caching.Redis | 2.2.0 |
| Newtonsoft.Json | 13.0.1 |
| Npgsql | 6.0.3 |
| Npgsql.EntityFrameworkCore.PostgreSQL | 6.0.3 |
| Swashbuckle.AspNetCore | 6.2.3 |

## Connecting API to Postgres and Redis

To connect Postgres and Redis just change connection strings accordingly to connection string

```sh
"ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1;Port=5432;Database=risewebapi;User Id=postgres;Password=recep;",
    "RedisConnection": "localhost:6379"      
  },
```

## API CALLS
### User Controller

| HTTP Method | Version | Definition |
| ------ | ------ | ------ |
| GET | api/User/GetUser |  Gets all Users  |
| GET | api/User/GetUserById/{id} |  Gets User with id |
| GET | api/User/GetAllActiveUser |  Gets only Users with  IsActive field true |
| GET | api/User/UpdateUser |  Updates an existing User |
| GET | /api/User/GetUserWithContact/{id} |  Gets User with All Contact Info |
| POST | api/User/AddUser |  Adds a new User |
| PUT | api/User/UpdateUser |  Updates an existing User |
| PUT | api/User/UpdateUser |  Changes User's IsActive field |
| DELETE | api/User/DeleteUser |  Deletes User's record |

### Contact Controller

| HTTP Method | Version | Definition |
| ------ | ------ | ------ |
| GET | api/Contact/GetContacts |  Gets all Contacts  |
| GET | api/Contact/GetContactById/{id} |  Gets Contact with id |
| GET | api/Contact/GetAllActiveContatcts |  Gets only Contacts with  IsActive field true |
| GET | api/Contact/UpdateContact |  Updates an existing Contact |
| GET | /api/Contact/GetContactWithUserId/{id} |  Gets Contact with a UserId  |
| POST | api/Contact/AddContact |  Adds a new Contact |
| PUT | api/Contact/UpdateContact |  Updates an existing Contact |
| PUT | api/Contact/UpdateContact |  Changes Contact's IsActive field |
| DELETE | api/Contact/DeleteContact |  Deletes Contatc's record |

### Report Controller

| HTTP Method | Version | Definition |
| ------ | ------ | ------ |
| GET | api/Report/GetLocations |  Gets all Contacts  |
| GET | api/Report/GetCountByLocation/{location} |  Gets User count on a specific location |
| GET | api/Report/GetTelNumberCountByLocation/{location} |  Gets tel number count on a specific location |
| GET | api/Report/GetReportFromCache/{reportID} |  Gets old reports from Redis Cache |


**Recep ÇAVUŞOĞLU**

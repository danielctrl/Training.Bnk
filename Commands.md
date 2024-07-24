# Commands
These commands are intended to be used as reference for running the system while a final solution is not implemented.

## Running Postgres in Docker
``` bash
docker run --name bnk-Account -e POSTGRES_PASSWORD=psword -e POSTGRES_USER=usr -e POSTGRES_DB=Account -d -p 5432:5432 postgres
```

## Migrations
``` bash
cd \src\Account\Account.Infrastructure

dotnet tool install --global dotnet-ef

dotnet ef migrations add --startup-project ../Account.Api MigrationName
dotnet ef database update --startup-project ../Account.Api
dotnet ef migrations remove --startup-project ../Account.Api

```

Assembly 'Account.Infrastructure' uses 'Microsoft.EntityFrameworkCore, Version=8.0.7.0'
	which has a higher version than referenced assembly 'Microsoft.EntityFrameworkCore' Account.Api	C:\Users\danie\source\repos\danielctrl\bnk\src\Account\Account.API\CSC	1	

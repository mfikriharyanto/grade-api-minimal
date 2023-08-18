## Starting Container SQL Server 2019

```
docker run --name mssql -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=[SA_PASSWORD_HERE]" -v sqlvolume:/var/opt/mssql -p 1433:1433 -d --rm mcr.microsoft.com/mssql/server:2019-latest
```

## Connect to Container SQL Server 2019 using sqlcmd

```
docker exec -it mssql /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P [SA_PASSWORD_HERE]
```
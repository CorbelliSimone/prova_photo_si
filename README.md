# INTRODUZIONE

Progetto di prova pratica per PhotoSi di **Simone Corbelli**.

# PREREQUISITI

Tutti i servizi sono stati creati con:
 1. **DOT NET. 6** scaricabile da [qui](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
 2. **PostgreSql 16** scaricabile da [qui](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads). Vengono pero' supportati anche vecchie versione di postgres
 3. **Visual studio 2022**
>  Ogni microservizio al primo avvio si occupa di **creare in automatico** il proprio database ed effettuarne un **seeding**, in piu' per ogni microservizio e' presente un **appsettings.json** e un **appsettings.Development.json** automaticamente usato in fase di debug.

# SERVIZI

#### - [ApiService (Api Gateway)](#ApiService)
#### - [Orders Service](#OrdersService)
#### - [AddressBook Service](#AddressBookService)
#### - [Products Service](#ProductsService)
#### - [Users Service](#UsersService)

## ApiService (Api Gateway)
<a name="ApiService"></a>

## Orders Service <a name="OrdersService"></a>
Servizio che si occupa di piazzare gli ordini, espone delle api REST richiamate dall'api gateway. Di default parte sulla porta **9003**, e' comunque possibile modificarla cambiandola nel file **launchSettings.json**. Di default crea il database con nome **order**. Il file di **appsettings.json** e **appsettings.Development.json** sono strutturati nel seguente modo:

| Proprieta'   | Tipo   | Descrizione                   |
|--------------|--------|-------------------------------|
| PostgreSql   | string | Stringa di connessione al database |

## AddressBook Service <a name="AddressBookService"></a>
Servizio che si occupa di gestire gli indirizzi, espone delle api REST richiamate dall'api gateway. Di default parte sulla porta **9002**, e' comunque possibile modificarla cambiandola nel file **launchSettings.json**. Di default crea il database con nome **address_book**. Il file di **appsettings.json** e **appsettings.Development.json** sono strutturati nel seguente modo:

| Proprieta'   | Tipo   | Descrizione                   |
|--------------|--------|-------------------------------|
| PostgreSql   | string | Stringa di connessione al database |

## Products Service <a name="ProductsService"></a>
Servizio che si occupa di gestire i prodotti, espone delle api REST richiamate dall'api gateway. Di default parte sulla porta **9001**, e' comunque possibile modificarla cambiandola nel file **launchSettings.json**. Di default crea il database con nome **product**. Il file di **appsettings.json** e **appsettings.Development.json** sono strutturati nel seguente modo:

| Proprieta'   | Tipo   | Descrizione                   |
|--------------|--------|-------------------------------|
| PostgreSql   | string | Stringa di connessione al database |

## Users Service <a name="UsersService"></a>
Servizio che si occupa di gestire gli utenti, espone delle api REST richiamate dall'api gateway. Di default parte sulla porta **9004**, e' comunque possibile modificarla cambiandola nel file **launchSettings.json**. Di default crea il database con nome **user**. Il file di **appsettings.json** e **appsettings.Development.json** sono strutturati nel seguente modo:

| Proprieta'   | Tipo   | Descrizione                   |
|--------------|--------|-------------------------------|
| PostgreSql   | string | Stringa di connessione al database |
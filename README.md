# INTRODUZIONE

Progetto di prova pratica per PhotoSi di **Simone Corbelli**.

# PREREQUISITI

Tutti i servizi sono stati creati con:
 1. **DOT NET. 6** scaricabile da [qui](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
 2. **PostgreSql 16** scaricabile da [qui](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads). Vengono pero' supportati anche vecchie versione di postgres
 3. **Visual studio 2022**

# SERVIZI

## API-GATEWAY
#### - [ApiService (Api Gateway)](#ApiService)

## MICROSERVIZI
>  Ogni microservizio e' corredato di test e al primo avvio si occupa di **creare in automatico** il proprio database ed effettuarne un **seeding**, in piu' per ogni microservizio e' presente un **appsettings.json** e un **appsettings.Development.json** automaticamente usato in fase di debug.
#### - [Orders Service](#OrdersService)
#### - [AddressBook Service](#AddressBookService)
#### - [Products Service](#ProductsService)
#### - [Users Service](#UsersService)

## ApiService (Api Gateway) <a name="ApiService"></a>
Servizio di Api Gateway che si occupa di contattare tutti i microservizi, espone delle api REST.
Il servizio prevede un controller **UserController** con cui simulare la **registrazione utente** e il **login utente**, una volta effettuato il login, e' possibile, semrpe tramite **UserController** associare un indirizzo all'utente, e' poi possibile piazzare un ordine tramite **OrderController** passandogli **Nome ordine** e **lista degli id degli ordini con le quantita'**.
Sono comunque disponibili tutti i controller per contattare i relativi microservizi ed ottenere/aggiungere/modificare **Utenti**, **Prodotti**, **Indirizzi** e **Ordini**.
Di default parte sulla porta **9000**, e' comunque possibile modificarla cambiandola nel file **launchSettings.json**.
I file di appsettings.json e appsettings.Development.json sono strutturati nel seguente modo:

| Proprieta'            | Tipo   | Default                    | Descrizione                      |
|-----------------------|--------|----------------------------|----------------------------------|
| ProductServiceUrl     | string | http://localhost:9001/api/ | Url del microserizio Product     |
| AddressBookServiceUrl | string | http://localhost:9002/api/ | Url del microserizio AddressBook |
| OrderServiceUrl       | string | http://localhost:9003/api/ | Url del microserizio Order       |
| UserServiceUrl        | string | http://localhost:9004/api/ | Url del microserizio User        |

## Orders Service <a name="OrdersService"></a>
Servizio che si occupa di piazzare gli ordini, espone delle api REST richiamate dall'api gateway.
Di default parte sulla porta **9003**, e' comunque possibile modificarla cambiandola nel file **launchSettings.json**.
Di default crea il database con nome **order**.
I file di **appsettings.json** e **appsettings.Development.json** sono strutturati nel seguente modo:

| Proprieta'   | Tipo   | Descrizione                   |
|--------------|--------|-------------------------------|
| PostgreSql   | string | Stringa di connessione al database |

## AddressBook Service <a name="AddressBookService"></a>
Servizio che si occupa di gestire gli indirizzi, espone delle api REST richiamate dall'api gateway.
Di default parte sulla porta **9002**, e' comunque possibile modificarla cambiandola nel file **launchSettings.json**.
Di default crea il database con nome **address_book**.
I file di **appsettings.json** e **appsettings.Development.json** sono strutturati nel seguente modo:

| Proprieta'   | Tipo   | Descrizione                   |
|--------------|--------|-------------------------------|
| PostgreSql   | string | Stringa di connessione al database |

## Products Service <a name="ProductsService"></a>
Servizio che si occupa di gestire i prodotti, espone delle api REST richiamate dall'api gateway.
Di default parte sulla porta **9001**, e' comunque possibile modificarla cambiandola nel file **launchSettings.json**.
Di default crea il database con nome **product**.
I file di **appsettings.json** e **appsettings.Development.json** sono strutturati nel seguente modo:

| Proprieta'   | Tipo   | Descrizione                   |
|--------------|--------|-------------------------------|
| PostgreSql   | string | Stringa di connessione al database |

## Users Service <a name="UsersService"></a>
Servizio che si occupa di gestire gli utenti, espone delle api REST richiamate dall'api gateway.
Di default parte sulla porta **9004**, e' comunque possibile modificarla cambiandola nel file **launchSettings.json**.
Di default crea il database con nome **user**.
I file di **appsettings.json** e **appsettings.Development.json** sono strutturati nel seguente modo:

| Proprieta'   | Tipo   | Descrizione                   |
|--------------|--------|-------------------------------|
| PostgreSql   | string | Stringa di connessione al database |
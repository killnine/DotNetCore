# DotNetCore Project #

## Intent ##

The DotNetCore solution is designed to be a proof-of-concept solution using a handful of technologies that I am already familiar with, but within a .NET Core context. 
The goal is to find any issues with implementing the technologies without being on the full .NET framework.

## Key Features / Demos ##

### Data Access ###
* Oracle Database Integration (Abandoned, Unsupported 1/20/18)
* Mongo Database Integration  (On Hold)
* SQL Server Database Integration (On Hold)
* PostgreSQL (Active)

### Messaging ###
* ActiveMQ Integration (Abandoned, Unsupported 1/20/18)
* RabbitMQ Integration (Active)

### Security ###
* ADFS Integration / Security (On Hold, Requirements Pending)

### Logging ###
* Usage Logging (Active)
* Performance Logging (Active)
* Error Logging (Active)

### Miscellaneous ###
* Environment Variables (Active)
* Application Parameters (Active)

## Open Issues ##

* Apache.NMS.ActiveMQ is dependent on .NET 4.6.1
* Oracle has released a statement about supporting .NET Core by [end of year 2017](http://www.oracle.com/technetwork/topics/dotnet/tech-info/odpnet-dotnet-core-sod-3628981.pdf)
* Mongo has a driver that [supports .NET core](https://mongodb.github.io/mongo-csharp-driver/)

## Docker ##

Docker will be used to run instances of these tools. Since I don't use Docker regularly in production, I'll include notes on how to spin up dependencies through Docker commands below

* docker run -d --hostname my-rabbit --name dotnet-test -p 8080:15672 -p 5672:5672 rabbitmq:3-management
* https://docs.docker.com/samples/library/rabbitmq/#erlang-cookie

## Business Functionality ##

The application will simulate the flow of machine data up through an enterprise system. There are a few components to this system:

* Machine Message Producers
    - Submits raw machine data to the system for it to be ingested
* Machine Message Consumers
    - Receives raw machine data from the RabbitMQ bus
    - Converts to domain model
    - Persists raw data to Postgres
    - Persists data to the database
* Front-End Display
    - Display raw data
    - Display model data

## Message Queue Hierarchy ##

* Device.<DeviceType>: This ensures that any consumer of a given <DeviceType> can parse that message, in theory




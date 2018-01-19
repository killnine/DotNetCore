# DotNetCore Project #

## Intent ##

The DotNetCore solution is designed to be a proof-of-concept solution using a handful of technologies that I am already familiar with, but within a .NET Core context. 
The goal is to find any issues with implementing the technologies without being on the full .NET framework.

## Key Features / Demos ##

### Data Access ###
* Oracle Database Integration
* Mongo Database Integration
* SQL Server Database Integration

### Messaging ###
* ActiveMQ Integration

### Security ###
* ADFS Integration / Security

### Logging ###
* Usage Logging
* Performance Logging
* Error Logging

### Miscellaneous ###
* Environment Variables
* Application Parameters

## Open Issues ##

* Apache.NMS.ActiveMQ is dependent on .NET 4.6.1
* Oracle has released a statement about supporting .NET Core by [end of year 2017](http://www.oracle.com/technetwork/topics/dotnet/tech-info/odpnet-dotnet-core-sod-3628981.pdf)
* Mongo has a driver that [supports .NET core](https://mongodb.github.io/mongo-csharp-driver/)
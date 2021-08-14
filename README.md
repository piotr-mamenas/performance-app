# Splitbook - Portfolio Management App

## Description
Initially started as a 2 week DDD challenge Splitbook is a Financial Portfolio Management corporate app developed as a part of building my personal application portfolio.
This git repository should be treated as work-in-progress rather than the final product.

## Running
The application is configured to run with a local instance of SQL Server 2014 Express, in order to setup the database run
update-database from the nuget commandline to run the migrations. Once the database is set up simply compile and run from Visual Studio 2017.
Username: DemoUser
Password: Secret1#

## Current Features
- Add and Edit Contacts, Partners, Accounts, Portfolios, Widgets
- List Contacts, Partners, Accounts, Assets, Exchange Rates, Portfolios and Tasks (w/ pagination, sorting and search)
- Close Account, Contact, Partner
- View Portfolio Details i.e Linked Partners and Assets with its prices
- Calculate Portfolio Assets Holding Period Return
- Download Pdf Reports from remote storage
- Log into the system

## Patterns and Practices Used
- Domain Driven Design
- Onion Architecture, Service Oriented Architecture
- Unit of Work and Repository Patterns
- SOLID
- Revealing Module Pattern
- IoC (Dependency Injection)
- Minor: Data Transfer Object, ViewModel, Sitemap
- Standard Gang of Four: Facade, Singleton, Factory, Decorator

## Api 
The application exposes a standard set of async crud REST services which allow interacting with the application and fetching json serialized data. A service is
exposed for each aggregate root of the domain model. By default the service is hosted on the 60520 port i.e localhost:60520/ running from iis express.

All standard routes are prefixed with /api.
example GET:
localhost:60520/api/contacts/1

## Dependencies
### .NET
MVC 5, Entity Framework 6 (Code First), Web Api 2, AutoMapper, FluentValidation, Ninject, NUnit, log4Net, Identity Framework 2, Owin, Sitemap, Newtonsoft, Attribute Routing

### JavaScript 
jQuery, underscore.js, bootbox.js, datatables, bootstrap, moment.js

### CSS
bootstrap, font-awesome, admin theme bootstrap metro ui

## Tests
The tests should be run with reSharper, the project has low test coverage as TDD falls out of the scope of this exercise.

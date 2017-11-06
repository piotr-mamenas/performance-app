# Splitbook - Performance & Risk Reporting App

## Description
Initially started as a 2 week Domain Driven Development challenge Splitbook is a Performance & Risk Reporting application developed as a part of building my personal application portfolio.

In the final form it will allow calculating financial portfolio performance, creating pdf reports listing portfolio performance over a period of time, importing and exporting data through
ftp loaded csv files and displaying portfolio performance on a visual chart. This git repository should be treated as work-in-progress rather than the final product. I commit daily so the project
changes rapidly.

## Installation
The application is configured to run with a local instance of SQL Server 2014 Express, in order to setup the database run
update-database from the nuget commandline to run the migrations. Once the database is set up simply compile and run from Visual Studio 2017.

Username: DemoUser
Password: Secret1#

## Backend
The backend is built according to the DDD best practices for domain modelling using ms recommended table per hierarchy (aggregate root) architecture. For data
access the app uses entity framework 6 as the orm of choice with fluent api code first configurations. To decouple the data access from
the orm the app makes use of a repository/unitofwork pattern. All relevant repositories and services are injected directly into controllers and domain models with ninject as the ioc of choice.

On top of that the application exposes a standard set of async crud restful services which allow interacting with the application and fetching json serialized data. A service is
exposed for each aggregate root of the domain model. By default the service is hosted on the 60520 port i.e localhost:60520/ running from iis express.

All standard routes are prefixed with /api.
example GET:
localhost:60520/api/contacts/1

## Frontend
The frontend is a mixture of MVC 5 (MVVM) for data posting and jquery ajax calls on the restful services exposed by the application for
additional data feeds (example: tracking selection and ad-hoc queries). This way I can take advantage of the default MVC 5 validation with 
unobtrusive javascript while still keeping the application fully responsive on data read. 

The site uses bootstrap 3 with admin metro ui theme and font-awesome. DOM manipulation and querying is done with jquery.

To ensure good separation of concerns and avoid spaghetti code javascript is organized with revealing module pattern using closures.

## Dependencies
### CSS
bootstrap, font-awesome, admin theme bootstrap metro ui

### JavaScript 
jQuery, underscore.js, bootbox.js, datatables, bootstrap, moment.js

### .NET
MVC 5, Entity Framework 6, Web Api 2, AutoMapper, Ninject, NUnit, log4Net, EF6, Identity Framework, Owin, Sitemap, Newtonsoft

## Tests
There is no test runner included. The tests should be run with reSharper.. Once they are there naturally.
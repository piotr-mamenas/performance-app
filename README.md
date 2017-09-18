# Splitbook - Portfolio Performance & Risk Reporting App

## Description
Initially started as a 2 week DDD challenge Splitbook is a performance & risk reporting application developed as a part of building
my personal application portfolio. The application is meant to show what kind of code can be expected from me in a professional setting.

In the final form it will allow calculating financial portfolio performance, creating pdf reports, importing and exporting data through
ftp loaded csv files and displaying portfolio performance on a visual chart. Much of the functionality is yet to be implemented so the
repository should be treated as work-in-progress.

## Installation
The application is configured to run with a local instance of SQL Server 2014 Express, in order to setup the database run
update-database from the nuget commandline. Once the database is set up simply compile and run from Visual Studio 2017

## Backend
The backend is built according to the DDD best practices for domain modelling using table per hierarchy (with aggregate root). For data
access the app uses entity framework 6 as the orm of choice with fluent api code first configurations. To decouple the data access from
the orm the app makes use of repository pattern. All relevant repositories and services are injected directly into controllers and domain models with ninject as the ioc of choice.

On top of that the application exposes a standard set of async crud restful services which allows interacting with the application and fetching data. A service is
exposed for each aggregate root of the domain model. By default the service is hosted on the 60520 port i.e localhost:60520/ running from iis express.

All standard routes are prefixed with /api.
example GET:
localhost:60520/api/contacts/1

## Frontend
The frontend is a mixture of MVC 5 MVVM for data posting and jQuery Ajax calls on the restful services exposed by the application for
additional data feeds (i.e selection) and querying, this way I can take advantage of the default MVC 5 validation with 
unobtrusive javascript while still keeping the application fully responsive on data read. Javascript is modularized with revealing module pattern.
This provides a neat separation of reading and writing improving overall separation of concerns.

As far as styling and site format goes the framework used is bootstrap with custom icons from font-awesome and an admin style ui.

## Dependencies
### CSS
bootstrap, font-awesome, admin theme bootstrap metro ui

### JavaScript 
jQuery, underscore.js, bootbox.js, jquery Datatables, bootstrap, moment.js

### .NET
AutoMapper, Ninject, NUnit, log4Net, EF6, WebApi2, Identity Framework, Owin, Sitemap, Newtonsoft

## Tests
There is no test runner included. The tests should be run with reSharper.
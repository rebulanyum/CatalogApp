# CatalogApp
This project is created for a job application.

Basicly this application is for listing, editing, viewing, deleting and exporting(Excel) Product entities. There are 2 applications: WebAPI & WebSite: 
  WebSite: It accesses to WebAPI via browser only. It contains web resources (html, css, javascript) and used to generate web pages. Used technologies: AspNetCore 2.1, AngularJS.Core 1.7.5, ui-cropper 1.0.4
  WebAPI: The only application that manages database is WebAPI. It is accessed by it's RESTFUL API from the WebSite. It is documented and it's documentation can be accessed too. In general it is created for handling Product actions. WebAPI includes 2 versions fo the same Product API which are running side by side. Used Technologies: AspNetCore 2.1, Swashbuckle.AspNetCore 4.0.1, Swagger Utilities, EPPlus 4.5.2.1, Microsoft.EntityFrameworkCore.SqlServer 2.1.4
  
The database of this project is SQL Server Express LocalDB together with ".mdf" file.

The Test project uses Moq 4.10.1 & MSTest 1.3.2

In order to run the application:
1) Place the database file (.mdf) in a folder.
2) On the WebAPI project's appsettings.json file change the database connection string with the name "rebulanyum.CatalogApp".
3) On the WebSite project's appsettings.json file set the "WebAPIBaseAddress" value with the WebAPI's base URL.
4) Hit F5

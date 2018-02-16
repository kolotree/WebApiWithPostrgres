# WebApiWithPostrgres
Integrating Web API with PostgreSQL

Using PostgreSQL as a database for Web API authentication is fairly easy and straightforward. 
The key step is to introduce custom UserStore in IdentityConfig.cs and to handle creating and searching User in your own way.
There is also an option to use your custom User entity in which case you would extent auto generated ApplicationUser and replaced it 
with your own User entity. This is fully working code for WebApi authentication with PostgreSQL. 

Database Scripts for creating User table and stored procedures are in DatabaseScripts folder.

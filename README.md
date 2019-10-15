# UserAdminApp
User admin app: provides examples of web api (GET, POST, PUT) to manage user adminstration, 
these web apis are called from UserAdminAppAngular

## Edit config.json
change server in config.json file to your sql server name

## Run command to create Database :
dotnet ef database update 

## Run command to create migrations of tables in the database
dotnet ef migrations add InitialDb 


## Content :
- Creation of Web api
- Use DbContext
- Use repository
- Validation with view model class
- Use AutoMapper 

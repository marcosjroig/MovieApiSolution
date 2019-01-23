# Movie Api Solution
This is a .Net Core Web API implemented for Movies and rate the movies. It uses SQL Server 2017 and Unit testing.

## Requirements for Installation
- Visual Studio 2017 or VS Code
- .NET Core 2.2 framework
- SQL Server 2017

## Installation
This repo has 2 folders:
- __Database__: that has 3 scripts that need to be executed in order.
- __MovieApi__: is the Web API solution with a folder for the API, another one for the Model and another one for the Data Access Leyer. In addition there are Unit test projects.

After downloading this repo and unzip it, please follow the next instructions to configure everything.

### Database installation
1) Execute in order the scripts of the __"Database"__ folder
2) Verify in your SQL Server that the DB has been created and tables are populated with some data.

### Web Api
1) Open the solution of the folder __"MovieApi"__ with VS2017 or VS Code 
2) Change the property __"MovieDbContext"__ of the file __"appsettings.json"__ to set your SQL Server name and your credentials as well, in my case I am using Windows authentication
3) Compile the solution and press F5 to run the API
4) Now you are ready to start playing with it and run unit testing



# _Bakery App 3 Tokyo Drift_

#### By _**Skylar Brockbank**_

#### _A Bakery app_

## Technologies Used

* _C#_
* _.NET 5_
* _ASP.NET Core MVC_
* _dotnet script, REPL_
* _Razor View Engine_
* _MySQL and MySQL Workbench_
* _Git_
* _Pomelo Entity Framework for MySql_
* _Microsoft Entity Framework (Identity)_

## Description
_An application that displays baked goods by flavor category_


## Setup/Installation Requirements

### Application Setup
* _Install .NET 5.0 [here](https://dotnet.microsoft.com/download/dotnet/5.0)_

* _Click the green "Code" button and Download Zip _
* _Extract the contents of the zip file to a folder on your machine_
* _Navigate to the Factory Directory and `touch appsettings.json` and fill with the following_
```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=skylar_brockbank;uid=root;pwd=[YOUR-PASSWORD-HERE];"
    }
}
```
* _Replace `[YOUR-PASSWORD-HERE]` with your MySql Password.

* _alternatively you can [clone this repository](https://www.learnhowtoprogram.com/introduction-to-programming/git-html-and-css/practice-github-remote-repositories) from Git Hub_

### Database Setup

* _Download MySQL and MySQL Workbench to set up a local database_

* _Once installed, create a database from the included migration files by navigating to the Bakery Directory and typing into the terminal:_
  >dotnet ef database update

### To Run Application

* _Navigate to Factory production folder in terminal_

* _To download obj and bin files needed for the program to run, while still in Bakery folder type into the terminal:_
  >dotnet restore
* _To run the program, while still in the Bakery directory type into the terminal:_
  >dotnet run
#### Note: The server will not open automatically. The user will need to click on the live share link in terminal, or enter 'localhost:5000' URL into browser.


## Known Bugs

* _tbd_

## License

*[MIT](https://opensource.org/licenses/MIT) Licenced
*Copyright (c) _2021_ _Skylar Brockbank_
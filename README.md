# Project Owl
## API
The API for Project Owl allows for developers to integrate their modules and applications into the Owl Incident Management System. This API is developed using the .NET Core 2.1 SDK.

## Prerequisites
1. You must install the .NET Core SDK. You can download that [here](https://dotnet.microsoft.com/download).
2. For development on Windows, you will need at least Visual Studio 2017. For development on macOS, you will need Visual Studio for Mac. You can also use Visual Studio Code with the [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) from the VS Code Marketplace.
3. PostgreSQL database driver for local development. For example, on Mac, you can use [Postgres.app](https://postgresapp.com/)

## Machine setup
This code requires that the development have some environment variables for connecting to a database. The database provider is Postgres.

For Bash-based environments:

`export OwlApiDatabaseName=DATABASENAME`

`export OwlApiDatabaseHost=DATABASEHOST`

`export OwlApiDatabasePort=DATABASEPORT`

`export OwlApiDatabaseUser=DATABASEUSER`

`export OwlApiDatabasePass=DATABASEPASSWORD`

These should be placed in the Bash profile, usually located at `~/.bash_profile`. Replace each value with the appropriate database information.

In order for Visual Studio for Mac to read from environment variables, you must run Visual Studio from the terminal. The most efficient way to do this is to add an `alias` line to `~/.bash_profile`:

`alias vs='/Applications/Visual\ Studio.app/Contents/MacOS/VisualStudio &'`

Visual Studio can then be run from the terminal simply by typing `vs` and pressing the Enter key

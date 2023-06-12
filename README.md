# Kent's WebForms C# Course System

The app is designed to cater to users who are interested in enrolling in different courses. Users can browse through the available courses, view course details, and enroll in courses of their choice. The system provides a user-friendly interface to facilitate easy course selection and enrollment.

## User View
![Alt Text](https://i.imgur.com/biNTVli.gif)
## Admin View
![Alt Text](https://i.imgur.com/tFq7INT.gif)

## Getting Started

To get started with this project, follow the steps below:

### Prerequisites

- Visual Studio (version 2019 or higher)
- .NET Framework (version 4.8  or higher)
- SQL Server (version 2012 or higher)

### Installation

1. Clone the repository:

  ```
  git clone https://github.com/Lezo13/SkillsTest-Kent.git
  ```
2. Open the solution file (KentWebForms.sln) in Visual Studio.
3. Restore the NuGet packages by right-clicking on the solution in the Solution Explorer and selecting "Restore NuGet Packages".

4. Configure the Connection String

- Open the Web.config file located in the project root directory (KentWebForms > KentWebForms.App).
- Locate the <connectionStrings> section and update the DefaultConnection connection string to match your desired database.
- Replace the placeholder values (YOUR_CONNECTION_STRING) with the appropriate connection details.

```
<connectionStrings>
  <add name="DefaultConnection" connectionString="YOUR_CONNECTION_STRING" providerName="System.Data.SqlClient" />
</connectionStrings>
```

5. Execute the Entity Framework Migrations

- Open the Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console).
- Ensure that the default project selected in the Package Manager Console is your data project (KentWebForms.App).
- Run the following command to execute the EF migrations and update the database schema:

```
Update-Database
```
This command will apply any pending migrations to the database using the configured connection string.

6. Publish the Database Project

To publish the database project, follow these steps:

- Open the project in Visual Studio.
- Locate Infrastructure > KentWebForms.Data and Right-click on the KentWebForms.Data project in the Solution Explorer and select "Publish".
- Choose the appropriate publish target and ensure the target database connection string matches the one you configured in the Web.config file.
- Click "Publish" to initiate the publishing process. This will update the database with the latest schema and deploy the database project to the specified target.

7. Run the Application

Once the database is updated and the data project is published, you can run the application by following these steps:

- Ensure the startup project is KentWebForms.App in Visual Studio.
- Press F5 or click the "Start" button to run the application.
- The application will launch in your default web browser.
# University Registrar

#### By _**Oladeji Daniel**_

#### _A university registrar used to keep track of students and courses._

## Technologies Used

* C#
* .NET 5.0
* dotnet
* MySql/Workbench
* Entity Frameworkcore
* Git


## Description

A university registrar used to keep track of students and courses. You can do the following operations: 
* Add remove and edit student information into the system
* Add remove and edit course information into the system
* Assign students to courses
* Assign Students to departments

## Setup/Installation Requirements

* Make sure you have MySql Workbench installed on your computer.
* Make sure to have dotnet-ef installed too.<br>
<em>This project uses <code>dotnet-ef --version 3.0.0</code> which I have globally installed but you can install it however you want. 
* Download repo to your computer using either clone or the download link.
* Open the project in VScode or your terminal/IDE of choice.
* Create a <code>appsettings.json</code> file in the root directory of the project folder. And add the following code replacing anything in square brackets with the information it represents specific to the project database:
``` JSON
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[DATABASE-NAME-HERE];uid=[USER-ID-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}

```

Example of complete appsettings.json:
``` JSON
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=to_do_list;uid=root;pwd=MySuperStrongPassword;"
  }
}
```

### Test Setup/Installation

* Open the repo on your editor of choice/terminal
* Navigate to UniversityRegistrar.Tests directory in your terminal
* Run the following command to setup testing:  
<code>dotnet restore</code>
<code>dotnet ef database update</code>
<code>dotnet build</code>
<code>dotnet watch run</code>   


## License

_MIT_

Copyright (c) _2022_ _Oladeji Daniel__
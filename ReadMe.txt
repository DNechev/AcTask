1. AssecorTask general information

1.1 The API is implemented with CSV file persistance as well as EntityFramework for SQL-Server persistance.

1.2 Please note that the integration tests are written for the EF persistance in order to include a test for the "CreatePerson" POST functionality since the task requires not to change the given sample file,
therefore the POST method is not implemented in the CSV persistance.

1.3 In order to run the integration tests please comment the registration of the repositories for the CSV persistance in the "DependencyRegistration.cs".
I also left comments in the file itself. Both persistances are also tested using Postman.

1.4 Before running the Application please set the ConnectionString accordingly

1.5 The colors names which contain "umlaut" chars are replaced, because i had problems testing them with Postman, they are as follows:
gruen, weiss and tuerkis.

2. Implementation details

2.1 Architecture - Clean architecture

2.2 Design patterns used - Repository design pattern and Unit of work design pattern.

2.3 Technologies used - .NET Core Web API, EntityFrameworkCore, EntityFrameworkCoreInMemory, AutoMapper, MicrosoftAspNetCore.Mvc.Testing, xUnit and Bogus
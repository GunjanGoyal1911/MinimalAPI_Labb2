This API is built to perform the CRUD operation (Create, Read, Update,Delete) on product entity and get the data from the database. The application is built with .NET and uses Docker and Docker Compose for managing the running and testing of the application.

1. Clone this Repository
  Clone the repository to your local machine:
  git clone <URL-to-your-repository>

2. Ensure your appsettings.json contains the correct connection string to connect to the SQL Server database running in Docker.
   
      "ConnectionStrings": {   
          "ProductConnectionString": "Server=sql-server;Database= productDB;User Id=SA;Password=<YourStrong!Passw0rd>;TrustServerCertificate=True;",
      }

3. Add the SA password to your docker-compose.yml file.

4. Build and Start the Containers
   
    docker-compose up --build

5. Stop the Containers
   
   docker-compose down


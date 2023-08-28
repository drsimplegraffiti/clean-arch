###### Setup

- Domain Class Library
    - Does not depend on anything - Where you write your entity class
- Application
    - Depends on Domain, i.e you will click on the dependency and add the domain layer
    - We write the Skelatal business logic like the Interfaces
- Infrastructure Layer
    - Depends on the Application Layer i.e click on the application/dependency and add the Application layer]
- API layer aka Presentation Layer (where we perform the actual business logic)
    - Depends on the Application Layer
    - Depends also on Infrastructure Layer
    - We add our data access (db context)

---

##### Injecting the DbContext
Since we are getting the Db from the infrastructure layer, we need to inform the Api project 
```
// Db connection
builder.Services.AddDbContext<MovieDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConenction"),
        b => b.MigrationsAssembly("CleanMovie.API")
    ));
```


##### Force drop a db
```sql
USE master;
GO
ALTER DATABASE lucky
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE lucky;
GO
```
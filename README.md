Workshop week 34: Putting Entity Framework in a practical context

Fork/clone the repository

To run the program, go to the directory "GUI" (graphical user interface) from the root folder, and do a "dotnet run".

To make the features of the application work, implement the methods inside Infrastructure/Repository.cs and build the database model inside RepositoryDbContext.cs.

It is not necessary to change anything inside the user interface. However, if one wishes to do so, that is allowed.

The only NuGet package required, (EF Core SQLite) is already added as a dependency, so no need to install any new packages.

Check that you have a db.db file at the specified place (see Infrastructure/Repository.cs constructor to see the expected path of the database).

When this is finished, implement the following:

- A database seeder function that write data to the database if it is empty, so there is always test data.
- Add validators to business entities using C# attributes.

It can be a good idea to work in groups.

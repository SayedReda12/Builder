# Builder
In this project configured some methods for general use and its implementation example

- first register **services.AddBuilderDbContext()** and **services.RegisterByAssembly()** in **startup** class

The Generic Class in the **Builder.Common** project

- AddBuilderDbContext : use this extention method to register your DbContext and connectionString

-	To register your services in DI Container dynamically, just make your interface inherits from **ITransientDependenncy**, **IScopedDepandency**, **ISingletonDependency**
- Inject **IRepository<TEntity>** in your service and use all its functionality

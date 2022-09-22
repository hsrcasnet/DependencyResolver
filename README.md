# DependencyResolver
A simple dependency injection framework to demonstrate the core functionality such as registration and resolving of dependency trees.

### Download and Install DependencyResolver
This library is available on NuGet: https://www.nuget.org/packages/DependencyResolver.NET
Use the following command to install DependencyResolver.NET using NuGet package manager console:

    PM> Install-Package DependencyResolver.NET

You can use this library in any .NET project which is compatible to .NET Framework 4.5, .NET Standard 2.0 and higher.

### How it use DependencyResolver
The DependencyResolver provides two basic methods: Register and Resolve. Register allows to map abstractions to implementations at bootstrap time of an application. These registrations are sometimes also called services, service mappings or dependencies.
Later, at runtime of the application, the Resolve method is used to create instances for the registered services.

```C#
// Create a new dependency injection container
var resolver = new Resolver();

// Register dependencies
resolver.Register<ILogger, ConsoleLogger>();
resolver.Register<IPaymentService, PaymentService>();
resolver.Register<IPaymentServiceConfiguration, PaymentServiceConfiguration>();

// Resolve dependencies
var paymentService = resolver.Resolve<IPaymentService>();
paymentService.Charge(99m, new MasterCard());
```

### Disclaimer
Do not use DependencyResolver in production code!<br/>Use one of the well-known DI frameworks instead: Autofac, Unity, Ninject.

### Links
Original Source & Credits<br/>
http://www.pashov.net/code/dependency-injection-hood/

Autofac<br/>
https://autofac.org/

Unity Container<br/>
https://github.com/unitycontainer

Ninject<br/>
http://www.ninject.org/

Dependency Injection in ASP.NET Core<br/>
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2

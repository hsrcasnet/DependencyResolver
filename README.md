# DependencyResolver
A simple dependency injection framework to demonstrate the core functionality of a dependency injection framework such as Autofac, Unity, Ninject.

### How it use the DependencyResolver
The DependencyResolver provides two basic methods: Register and Resolve. Register allows to map abstractions to implementations at bootstrap time of an application. These registrations are sometimes also called services, service mappings or dependencies.
Later, at runtime of the application, the Resolve method is used to create instances for the registered services.

```
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

### Links
Autofac
https://autofac.org/

Unity Container
https://github.com/unitycontainer

Ninject
http://www.ninject.org/

Original Source & Credits
http://www.pashov.net/code/dependency-injection-hood/

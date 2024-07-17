# DependencyInjection Demo

It is small POC to understand Dependency Injection. Random number is being generated in DemoDi class. Different scopes are added through interfaces to check the behaviour.

The Singleton class is instantiated once when the execution starts.
The Scoped class is instantiated per Http Request.
The Transient class is instantiated every time it is present.

The output looks like this:

DISampleFuntion
numSingleton1 = 417952180 numScoped Call 1= 1875435956 numScoped Call 2= 1875435956 numTransient Call 1 = 2126769653 numTransient Call 2 = 1252731967

DISampleFuntion1
numSingleton1 = 417952180 numScoped Call 1= 467981180 numScoped Call 2= 467981180 numTransient Call 1 = 1691856302 numTransient Call 2 = 370037416

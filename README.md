# Getting Started with Dependency Injection in .NET

The Pluralsight course on C# Dependency Injection.

## Description of DI

A set of software design principles and patterns that enable to develop *loosely coupled code*.

* easy to extend
* easy to test
* easy to maintain
* facilitates parallel development
* facilitate late binding (descisions made at runtime rather than compile-time)

### SOLID prinicples

* S: single-responsibility - an object should have 1 reason to change
* O: open/closed
* L: liskov's substitution princople
* I: interface segrgation principle
* D: dependency inversion principle

### Good Patterns with DI

* **constructor injeciton**
* **property injection**
* method injection
* ambient context
* service locator

### Popular Containers

* **Autofac**
* **Ninject**
* Unity
* Castle Widnsor
* Spring.NET

## Code Demo Issues - Tight Coupling

The base form of the demo has heavy tight coupling.

* The `PeopleViewModel` news up a `ServiceReader()`, deciding the source of the data (presentation is coupled to data access).
* The `ServiceReader` news up a `WebClient`, meaning the data access layer is tightly coupled to the data store.

Every instance of `new` implies:

* a compile-time reference to the object
* lifetime responsibility

And, if we have to add new data sources, the the `PeopleViewModel` has to be expanded to allow for each new type, breaking the **Single Responsiblty** principle.


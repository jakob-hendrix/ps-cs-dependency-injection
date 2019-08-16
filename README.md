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

## Implementing DI

1. Break tight coupling by adding abstraction via interfaces
1. Use constructor injection
1. snap the loosly coupled pieces (object composition)

Decompose into abstract bits. Inject those bits via contructors from the object that wants to be resposnible for the lifetime of the dependecy.

### New features

1. ability to change the data source
1. option of client side cache
1. unit tests

### Repository pattern

The `prepository pattern` mediated between the domain and the data mapping layers using a collection-like interface for accessing domain objects

> application <-> repository <-> data store

The repo knows how to translate the data store into nromal C# objects.

#### CRUD repos

Create, read, update, delete

The `interface segerattuion princopl` says an interface should only contain what the client needs.

Since the client only needs Read operations, our interface should only have read operations

### Reducing coupling with DI

We don't want to maintain the lifecycle of the data access object. We can pass on that responsibility by using ocntructor injection.

### Bootstrappers

Bootstrappers are responsible for starting the application. This should be seperate form the view, so the view could be used by ,multiple bootstrappers.

Another level of decomp.

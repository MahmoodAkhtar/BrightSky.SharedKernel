# Getting Started BrightSky.SharedKernel
This is a project that I intended to eventually make it a nuget package which will then serve as a goto to get started on
future .NET Projects. It contains some custom more functional types. In particular the `Result<TResult, TError>` type, 
the `OneOf<T1,T2 ... T13>` type and also other types like `Error` and others. There are also several functional 
extension methods for each type.

## `Result<TResult, TError>`

The problem this type helps solve is that each method can have two states or outcomes. A success (i.e. happy) path or a 
failure (i.e. unhappy) path. This type makes it possible to represent both states and then allows the client code to 
handle them accordingly.

### TODO: show code examples

## `OneOf<T1, T2 ... T13>`

The problem this type helps solve is that when modelling a problem domain sometimes there is a need for a 'choice' type.
A type that can represent one of several possible mutually exclusive choices. This type makes it possible to represent 
several mutually choices and then allows the client code to handle them accordingly.

### TODO: show code examples

## `Error`

The problem this type helps solve is that instead of using .NET Exception classes for control flow and/or error states 
this type makes it possible to represent an error state. It can hold useful information and then be used with the 
`Result<TResult, TError>` type to allow better control flow based off of error states.

### TODO: show code examples

## `Option<TValue>`

The problem this type helps solve is the reliance on `null`. This type helps represent the idea a value may or may not 
exit. It can be `Some(...)` or `None` and then there are extension methods which help the client code to handle them 
accordingly.

### TODO: show code examples
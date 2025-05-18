## functional-csharp

This repository is an experimental project exploring functional programming techniques within the C# language.

While C# is a multi-paradigm language that supports functional programming alongside other styles, the majority of existing solutions tend to be predominantly object-oriented and imperative.

The aim of this project is to emphasize functional programming principles by minimizing object orientation and mutable state. Instead, it focuses on things like immutability or pure functions wherever possible.

> **NOTE:** It is acknowledged that the experiments conducted here not conform to idiomatic C# standards but rather serve as a learning platform and proof of concept.

### Project Structure

- **FunctionalCsharp.Core** – *ClassLibrary*, contains the primary logic and core classes  
- **FunctionalCsharp.Tests** – *TestProject*, implements tests for the core logic  
- **FunctionalCsharp.Web** – *Blazor*, provides a GUI for example user interaction

### Overview

| Concepts                               | Core                              | Web                                                 | 
|:---------------------------------------|:----------------------------------|:----------------------------------------------------|
| pure function, immutability, recursion | `CounterService.cs`, `Helpers.cs` | `Counter.razor(.cs)`, `CounterComponent.razor(.cs)` |
| option (some/none), map                | `Option.cs`                       | `Greeting.razor(.cs)`                               | 

using System.Collections.Immutable;
using FunctionalCsharp.Core.Models;
using Microsoft.AspNetCore.Components;

namespace FunctionalCsharp.Web.Components.Components;

public partial class CounterComponent : ComponentBase
{
    [Parameter] public ImmutableList<Counter> Counters { get; set; } = [];
    [Parameter] public EventCallback<int> OnIncrement { get; set; }
    [Parameter] public EventCallback<int> OnDecrement { get; set; }

    private Task Increment(int id) => OnIncrement.InvokeAsync(id);
    private Task Decrement(int id) => OnDecrement.InvokeAsync(id);
}

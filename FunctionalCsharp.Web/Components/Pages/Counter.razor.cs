using System.Collections.Immutable;
using FunctionalCsharp.Core.Services;
using Microsoft.AspNetCore.Components;

namespace FunctionalCsharp.Web.Components.Pages;

public partial class Counter : ComponentBase
{
    private ImmutableList<FunctionalCsharp.Core.Models.Counter> _counters = CounterService.InitCounters(3);

    private void Increment(int id)
    {
        _counters = CounterService.IncrementCounter(_counters, id);
    }

    private void Decrement(int id)
    {
        _counters = CounterService.DecrementCounter(_counters, id);
    }

    private void AddCounter()
    {
        _counters = CounterService.AddCounter(_counters);
    }
}

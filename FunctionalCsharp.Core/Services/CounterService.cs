using System.Collections.Immutable;
using FunctionalCsharp.Core.Models;

namespace FunctionalCsharp.Core.Services;

public static class CounterService
{
    public static int GetSum(ImmutableList<Counter> counters) =>
        counters.Sum(c => c.Value);

    public static ImmutableList<Counter> UpdateCounter(ImmutableList<Counter> counters, int id, Func<int, int> updateFunc) =>
        counters.Select(c =>
            c.Id == id ? c with { Value = updateFunc(c.Value) } : c
        ).ToImmutableList();

    public static ImmutableList<Counter> IncrementCounter(ImmutableList<Counter> counters, int id)
    {
        return UpdateCounter(counters, id, x => x + 1);
    }

    public static ImmutableList<Counter> DecrementCounter(ImmutableList<Counter> counters, int id)
    {
        return UpdateCounter(counters, id, x => x - 1);
    }
    public static ImmutableList<Counter> AddCounter(ImmutableList<Counter> list) =>
        list switch
        {
            { Count: 0 } => ImmutableList.Create(new Counter(1, 0)),
            _ => list.Add(new Counter(list[^1].Id + 1, 0))
        };

    public static ImmutableList<Counter> InitCounters(int n) =>
        Enumerable.Range(1, n)
                  .Select(i => new Counter(i, 0))
                  .ToImmutableList();
}



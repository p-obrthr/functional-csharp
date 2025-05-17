using System.Collections.Immutable;

namespace FunctionalCsharp.Core.Utilities;

public static class Helpers
{
    public static (T head, ImmutableList<T> tail)? Unconstruct<T>(ImmutableList<T> list) =>
        list switch
        {
            null or { IsEmpty: true } => null,
            var l => (l[0], l.RemoveAt(0))
        };

}

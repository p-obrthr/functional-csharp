namespace FunctionalCsharp.Core.Utilities;

public abstract class Option<T>
{
    public abstract TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none);
    public static Option<T> Some(T value) => new Some<T>(value);
    public static Option<T> None() => new None<T>();
}

public sealed class Some<T> : Option<T>
{
    private readonly T _value;
    public Some(T value)
    {
        _value = value;
    }
    public override TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
    {
        return some(_value);
    }
}

public sealed class None<T> : Option<T>
{
    public override TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
    {
        return none();
    }
}

public static class OptionExtensions
{
    public static Option<TResult> Map<T, TResult>(this Option<T> option, Func<T, TResult> mapFunc)
    {
        return option.Match(
            some: value => Option<TResult>.Some(mapFunc(value)),
            none: () => Option<TResult>.None()
        );
    }
}
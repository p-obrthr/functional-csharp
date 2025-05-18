using System.Collections.Immutable;
using FunctionalCsharp.Core.Utilities;
using Microsoft.AspNetCore.Components;

namespace FunctionalCsharp.Web.Components.Pages;

public partial class Greeting : ComponentBase
{
    private Option<string> _userNameOption = Option<string>.None();
    protected override void OnInitialized()
    {
        _userNameOption = GenerateUserNameOption();
    }

    private static Option<string> GenerateUserNameOption()
    {
        ImmutableList<string> names = ImmutableList.Create("Anna", "Bernd", "Clara", "David", "Eva");
        var random = new Random();
        var chance = random.NextDouble();

        return chance switch
        {
            var c when c > 0.5 => Option<string>.Some(names[random.Next(names.Count)]),
            _ => Option<string>.None()
        };
    }

    private string GetGreetingMessage =>
        _userNameOption
            .Map(name => $"Hello, {name.ToUpper()}!")
            .Match(
                some: known => known,
                none: () => "Hello, Unknown."
            );
}
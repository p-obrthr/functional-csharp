using FunctionalCsharp.Core.Utilities;

namespace FunctionalCsharp.Tests;

[TestClass]
public class OptionTests
{
    [TestMethod]
    public void TestOptionSome_ShouldMatchCorrectSome()
    {
        var maybeName = Option<string>.Some("Name");

        string greeting = maybeName.Match(
            some: name => $"Hello, {name}",
            none: () => "No Name"
        );

        Assert.AreEqual("Hello, Name", greeting);
    }

    [TestMethod]
    public void TestOptionMap_ShouldMapFunc()
    {
        var maybeValue = Option<int>.Some(5);

        var mapped = maybeValue.Map(x => x * 2);

        int result = mapped.Match(
            some: x => x,
            none: () => -1
        );

        Assert.AreEqual(10, result);
    }
}




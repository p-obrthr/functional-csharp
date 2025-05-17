using FunctionalCsharp.Core.Services;

namespace FunctionalCsharp.Tests;

[TestClass]
public class CounterServiceTests
{
    [TestMethod]
    public void InitCounters_ShouldCreateCorrectNumberOfCounters()
    {
       var counters = CounterService.InitCounters(3);

       Assert.AreEqual(3, counters.Count);
       Assert.IsTrue(counters.All(c => c.Value == 0));
    }

    [TestMethod]
    public void AddCounter_ShouldAddNewCounter()
    {
       var counters = CounterService.InitCounters(2);
       var newCounters = CounterService.AddCounter(counters);

       Assert.AreEqual(2, counters.Count);
       Assert.AreEqual(3, newCounters.Count);
       Assert.AreEqual(3, newCounters[^1].Id);
       Assert.AreEqual(0, newCounters[^1].Value);
    }

    [TestMethod]
    public void IncrementCounter_ShouldIncreaseAndDecreaseValue()
    {
       var counters = CounterService.InitCounters(1);
       var incremented = CounterService.IncrementCounter(counters, 1);

       Assert.AreEqual(0, counters[0].Value);
       Assert.AreEqual(1, incremented[0].Value);

       var added = CounterService.AddCounter(incremented);
       var incrementedNew = CounterService.IncrementCounter(added, 2);
       var decremented = CounterService.DecrementCounter(incrementedNew, 1);

       Assert.AreEqual(0, decremented[0].Value);
       Assert.AreEqual(1, decremented[1].Value);
    }

    [TestMethod]
    public void GetSum_ShouldReturnSumOfAllCounterValues()
    {
       var counters = CounterService.InitCounters(3);
       var incremented = CounterService.IncrementCounter(counters, 1);
       incremented = CounterService.IncrementCounter(incremented, 2);
       incremented = CounterService.IncrementCounter(incremented, 3);

       int sum = CounterService.GetSum(incremented);

       Assert.AreEqual(3, sum);
    }
}

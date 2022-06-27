**Previous:** [Sort an array](arrays-sort)

# Find the best historical time to buy and sell stocks

**Difficulty:** Medium.

Implement the `BestBuySellTime` method below so that it calculates the best historical time to buy and sell a stock in order to maximize gain. Return `null` in case it's not possible to find a solution that would result in a gain.

Don't use any library method.

### Did you know?

You can use [tuples](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples) like `(DateTime Buy, DateTime Sell)` when having to return multiple values from a method. This is often preferable to using `out` parameters.

*Tuples* are also known as "value tuples" to distinguish them from an older C# feature: [System.Tuple](https://docs.microsoft.com/en-us/dotnet/api/system.tuple) which is seldom used nowadays.

Because *value tuples* are *value types*, they cannot be `null`. For this reason `BestBuySellTime` uses the `?` syntax to mark the return value as nullable.

### Did you know?

C# [records](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records) are a compact way to define types that are simply a composition of fields. *Records* have many other interesting properties.

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester)

---

**Next:** [Convert an array to a linked list and back](lists-arrayToList)
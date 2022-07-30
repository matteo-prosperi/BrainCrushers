**Previous:** [Longest increasing sequence](arrays-longestIncreasingSequence)

# Maximum average of increasing sequence

**Difficulty:** Easy.

Complete the `FindMaxAverageOfIncreasingSequence` method below returning the maximum average of the sequences of increasing values in the input array. First of all identify the sequences of increasing values like in the [previous exercise](arrays-longestIncreasingSequence), then calculate the average of each sequence and return the highest one. If the input array is empty, return `null`.

Do not use library methods.

### Did you know?

In C# [value types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types) like numbers (`int`, `double`, `byte`, etc.) and characters cannot be `null`. If a value type variable may on occasion be unavailable, you can make it nullable by adding `?` to the type (E.g., `int?`). The `FindMaxAverageOfIncreasingSequence` method returns a nullable double (`double?`) because under certain circumstances (when the input array is empty) the result is not available.

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester)

---

**Next:** [Find a value](arrays-findValue)
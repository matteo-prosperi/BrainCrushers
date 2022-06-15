**Previous:** [Escape a char array](arrays-escape)

# Longest increasing sequence

**Difficulty:** Easy.

Complete the `FindLongestIncreasingSequence` method below returning the start index and length of the longest sequence of increasing values in the input array. A sequence terminates when a value is found which is smaller or equal than its predecessor. Return `(0, 0)` if the input array is empty.

Do not use library methods.

### Did you know?

C# supports [tuples](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples) which are a convenient method to return multiple values from a method. Using tuples is often preferable to using `out` parameters.

### Did you know?

C# supports [generics](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics) allowing a method or class to work with multiple types of data.

For example, the `FindLongestIncreasingSequence` method below works with arrays independently from the type of their elements: the code uses the placeholder `T` to represent such type.

In this case, a [constraint](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters) is placed on `T` requiring the implementation of [IComparable<T>](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1), which means that you can use the [CompareTo](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1.compareto) method on array elements to evaluate when a increasing sequence terminates.

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester)

---

**Next:** [Maximum average of increasing sequence](arrays-maxAverageOfIncreasingSequence)
**Previous:** [Find the best historical time to buy and sell stocks](arrays-buySell)

# Print a matrix

**Difficulty:** Very easy.

Complete the `Print` method below to print the [2-dimensional array](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays) passed as parameter. Use the `'\t'` character to separate elements within the same line and `Environment.NewLine` to separate different lines.

For example, the array `new int[,] { { 1, 2 },{ 3, 4 } }` should be printed as `$"1\t2{Environment.NewLine}3\t4"`.

Don't use any library methods.

### Tip

Don't include any extra `'\t'` character at the end of the line and any extra `Environment.NewLine` at the end of the matrix. For example, a 0-by-0 matrix should result in an empty string.

### Did you know?

Different platforms use different character sequences to represent a new line. For example, Windows uses `"\r\n"`, Linux uses only `"\n"`. To make your code portable, use [Environment.NewLine](https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline) or one of the .NET methods that add a line break like [StringBuilder.AppendLine](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.appendline).


[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester)

---

**Next:** [Implement a 3x3 matrix type](matrices-operations)
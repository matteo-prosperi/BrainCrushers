**Previous:** [Is a string a palindrome?](strings-palindrome)

# Reverse a string

**Difficulty:** very easy.

Complete the code of the `Reverse` method below to return a string composed of the input characters in the reverse order. For example `Reverse("Foo")` should return `"ooF"`.

DO NOT use any library method like `Enumerable.Reverse`.

### Did you know?

In C# [strings are immutable](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#immutability-of-strings): once a string is created, it cannot be modified. Appending a character to a string (or any other operation like [ToUpper](https://docs.microsoft.com/en-us/dotnet/api/system.string.toupper) or [Replace](https://docs.microsoft.com/en-us/dotnet/api/system.string.replace)) creates a new string making a copy of all the existing text. This means that creating a long string by appending characters to it multiple times is very inefficient, you should use the [StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder) class instead. 

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester)

### Tip

For even better performance, since you know in advance the length of the resulting string, you can create the `StringBuilder` specifying its capacity with `new StringBuilder(text.Length)`.

---

**Next:** [Are they anagrams?](strings-anagrams)
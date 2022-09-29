**Previous:** [Are they anagrams?](strings-anagrams)

# Escape a string

**Difficulty:** very easy.

Complete the code of the `Escape` method below to replace `\` characters in the input string with `\\` and `"` characters with `\"`.

DO NOT use any library method like `String.Replace`.

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester)

### Did you know?

When writing a string literal (a constant string value) in code, certain characters are not allowed. For example in C# the `"` character is not allowed because it is used to mark the end of the string. [Escaping](https://en.wikipedia.org/wiki/Escape_character) is the process replacing a forbidden characters with a special sequence of characters. In C#, this is achieved by using the special character `\` to identify the start of one of [these sequences](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#string-escape-sequences). For example, `Any "quoted text" is escaped with the \ character` can be written as the C# string `"Any \"quoted text\" is escaped with the \\ character"`. As you can see, because the `\` character has a special meaning, it needs to be escaped as well.

C# also allows to use [verbatim strings](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#verbatim-string-literals) to simplify writing string literals if they contain lots of characters that would need escaping. They are also very useful when the string literal is composed of multiple lines.

---

**Next:** [Split a string](strings-split)
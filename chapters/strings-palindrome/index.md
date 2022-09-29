# Is a string a palindrome?

**Difficulty:** very easy.

A [palindrome](https://en.wikipedia.org/wiki/Palindrome) is a piece of text that is equal to its reverse. In other words, when reversing the sequence of characters that make up the word, you end up with the same word. "madam" is an example of a palindrome.

Complete the code of the `IsWordPalindrome` method below.

For this method, let's only consider the input palindrome when it's exactly equal to its reverse:
- "Madam" is not considered a palindrome (due to the capitalized "M"),
- "top spot" is not considered a palindrome (due to having a single off-center space),
- "bob & bob" is considered a palindrome.

DO NOT use any library method like `Enumerable.Reverse`.

[](READONLY Intro 1)
[](EDITABLE Solution 1)
[](READONLY Outro 1)

Press the button below to test your solution

[](RUN BrainCrushersTests.Tester1)

---

**Difficulty:** Easy.

Now complete the code of the `IsPhrasePalindrome` method below.

For this method, let's consider the input palindrome when it's equal to its reverse ignoring capitalization and non-alphanumeric characters: "Madam", "top spot", and "Satire: Veritas" are all now considered palindromes;

[](READONLY Intro 2)
[](EDITABLE Solution 2)
[](READONLY Outro 2)

[](RUN BrainCrushersTests.Tester2)

---

If you want to experiment simplifying your code above by using some utility methods like [Enumerable.Reverse](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.reverse) or [Enumerable.SequenceEqual](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sequenceequal), you can change the `using` statements here:

[](EDITABLE Using statements)

---

**Next:** [Reverse a string](strings-reverse)
**Previous:** [Reverse a string](strings-reverse)

# Are they anagrams?

**Difficulty:** easy.

Two words are considered [anagrams](https://en.wikipedia.org/wiki/Anagram) they are both made of the same letters: rearranging the order of the letters in the first word, you can get the second.

Complete the code of the `AreAnagrams` method below.

For this method, let's only consider english alphabet letters (`a` to `z`, ignore any other character) and ignore capitalization (`A` and `a` are considered the same).

Feel free to use any library method.

[](EDITABLE Using statements)
[](READONLY Intro 1)
[](EDITABLE Solution 1)
[](READONLY Outro 1)

[](RUN BrainCrushersTests.Tester1)

---

**Difficulty:** Easy.

Now complete the code of the `AreAnagrams` method below which accepts multiple strings are returns `true` if all input strings are anagrams of each other.

### Did you know?

You can have multiple methods with the same name in the same class as long as they have different parameter types, this is called [method overloading](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/member-overloading).

### Tip

You can consider calling `AreAnagrams(string, string)` that you wrote above from `AreAnagrams(string[])` to leverage the existing solution. Does this make the solution easier? How does this affect performance?

[](READONLY Intro 2)
[](EDITABLE Solution 2)
[](READONLY Outro 2)

[](RUN BrainCrushersTests.Tester2)

---

Can you implement a variant `AreAnagrams2` which returns true if the two words are composed of exactly the same characters? In this case `A` is considered different from `a`; whitespace and non-letters are not ignored.

[](READONLY Intro 3)
[](EDITABLE Solution 3)
[](READONLY Outro 3)

[](RUN BrainCrushersTests.Tester3)

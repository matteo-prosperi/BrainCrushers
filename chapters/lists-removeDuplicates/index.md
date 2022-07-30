**Previous:** [Linked list operations](lists-operations)

# Remove duplicates

**Difficulty:** Easy.

Complete the `RemoveDuplicates` method below which takes a sorted linked list as input and removes duplicate numbers from it. For example, `1->3->4->4->5` should be changed into `1->3->4->5`.

Don't use any library method.

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester)

### Did you know?

The `RemoveDuplicates` method uses the `ref` keyword to take its parameter [by reference](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref#passing-an-argument-by-reference). Taking a parameter *by reference* allows a method to modify the caller's variable that is used as value for that parameter.

For example, the code below will print `1` because the `Increment` function takes `value` *by reference* making any change to `number` also apply to the variable used as value for the `number` parameter (in this case `n`).
```
int n = 0;
Increment(ref n);
Console.WriteLine(n);

void Increment(ref number)
{
    number++;
}
```

If the `number` parameter was not passed *by reference* the increment would not apply to the `n` variable since `number` would simply be a copy of `n`.

The mechanics of the `ref` keyword and the `out` keyword are actually very similar (make changes to the parameter visible to the caller) but they have very different purposes.

### Note

For the `RemoveDuplicates` method taking its parameter *by reference* is not strictly necessary because the duplicates removal can always be achieved preserving the *head node* of the list. Nonetheless, in most circumstances, modifying a linked list may result in changing it head. So, methods that take the head node of a list and modify the list itself have to take the head as a reference parameter.

### Did you know?

In order to fully understand how `ref` parameters work, it is important to understand the difference between [value types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types) (`int`, `float`, `double`, `char`, `bool`, `DateTime`, etc.,  and anything else declared with the `struct` keyword) and [reference types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types) (`string`, arrays, and anything declared with the `class` keyword).

A *value type* variable contains its actual value, a *reference type* variable contains a reference to the object itself (or `null`).

When a *value type* variable is passed as a "normal" (not *by reference*) parameter to a method, the method receives a copy of the value.

When a *reference type* variable is passed as a "normal" (not *by reference*) parameter to a method, the method receives a copy of the reference which results in both the caller and the method having different references to the same object. If the method changes a field or property of the shared object the change will be visible to the caller. If the method reassigns the parameter making it reference a different object, such change won't be visible to the caller.

When studying this topic, it's a good idea to investigate the concept of [boxing and unboxing](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing) as well as the [immutability of strings](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#immutability-of-strings).

### Note

All C# [built-in types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types) like `int` and `string` are language keywords (that's why their name is lower case and are usually shown in a different color in code editors). They have a corresponding .NET type like `System.Int32` and `System.String`. There is absolutely no difference in using the keyword or the .NET type name: `int` can freely be replaced with `System.Int32` and vice versa.

This can be unexpected for people who are familiar with the Java language where the `int` keyword represent a value while the [Integer](https://docs.oracle.com/javase/7/docs/api/java/lang/Integer.html) type is an actual object.

---

**Next:** [Merge sorted lists](lists-merge)
**Previous:** [Factorial](recursion-factorial)

# Factorial

**Difficulty:** Easy.

Complete the `Concatenate` method below to recursively concatenate into `stringBuilder` the content of `span`.

The `span` parameter is of type `TextSpan` which can either be a simple `string` or contain an array of `TextSpan`.

For example `new TextSpan("Foo", new TextSpan("Bar", "Baz"), "!")` should be concatenated into `"FooBarBaz!"`

Don't use any library methods.

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester)

### Did you know?

`TextSpan` may contain references to multiple children of the same type `TextSpan`. This data structure is called a "tree" and, in that context, a `TextSpan` object is called a "tree node". It is very common to write recursive code to interact with *trees*.

### Did you know?

The code for the `TreeSpan` class above uses the `readonly` keyword on all its fields to make the class "immutable". Immutability is a very common pattern when writing code, because it allows guarantees that data cannot be unexpectedly modified, which can help understanding the behavior of complex code.

### Did you know?

The code for the `TreeSpan` class above uses two separate constructors to guarantee that exactly one of the two fields `Text` and `Spans` is initialized and the other is `null`.

The constructors use `?? throw` to make sure that a `null` is not passed as parameter. You should always check the reference type parameters of public functions for unexpected `null` values.

### Did you know?

The [implicit operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators) above allows for `string` values to be implicitly converted to a `TextSpan`. When a `string` is used in such a way, the *implicit operator* will be invoked, executing the `TextSpan(string)` constructor and creating a new `TextSpan` object.

This allows simplifying the following code
```
var span = new TextSpan(new TextSpan[]
    {
        new TextSpan("Foo"),
        new TextSpan("Bar")
    });
```
into the more compact and readable
```
var span = new TextSpan(new TextSpan[] { "Foo", "Bar" });
```

### Did you know?

The [params](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/params) keyword is used in the `TextSpan(TextSpan[])` constructor to allow omitting the array creation and simply pass multiple `TextSpan` objects as parameters.

This allows simplifying the following code
```
var span = new TextSpan(new TextSpan[]
    {
        new TextSpan("Foo"),
        new TextSpan("Bar")
    });
```
into the more compact and readable
```
var span = new TextSpan(
    new TextSpan("Foo"),
    new TextSpan("Bar"));
```
Combining the advantages of the *implicit operator* and `params` the code can be further simplified into
```
var span = new TextSpan("Foo", "Bar");
```

---

**Next:** [Math expressions](recursion-math)
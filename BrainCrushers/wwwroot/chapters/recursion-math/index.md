**Previous:** [Concatenate](recursion-concatenate)

# Math expressions

**Difficulty:** Easy.

Complete the `Solve` method below by recursively calculating the value of `expression`.

As you can see below, an `Expression` object can be either a `Constant`, `Addition`, `Subtraction`, `Multiplication`, or `Division` object.

Don't use any library methods.

### Tip

You can use the C# operator [is](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/is) to identify the actual type of `expression`. For example:
```
if (expression is Constant constantExpression)
{
    Console.WriteLine($"The value is {constantExpression.Value}");
}
```

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)
[](READONLY Expression)
[](EDITABLE Expression Extra Code)
[](READONLY Expression Outro)
[](READONLY Constant)
[](EDITABLE Constant Extra Code)
[](READONLY Constant Outro)
[](READONLY BinaryOperation)
[](EDITABLE BinaryOperation Extra Code)
[](READONLY BinaryOperation Outro)
[](READONLY Addition)
[](EDITABLE Addition Extra Code)
[](READONLY Addition Outro)
[](READONLY Subtraction)
[](EDITABLE Subtraction Extra Code)
[](READONLY Subtraction Outro)
[](READONLY Multiplication)
[](EDITABLE Multiplication Extra Code)
[](READONLY Multiplication Outro)
[](READONLY Division)
[](EDITABLE Division Extra Code)
[](READONLY Division Outro)

[](RUN BrainCrushersTests.Tester)

### Note

The `ToString()` implementations above are also recursive since [string interpolation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated) relies on `ToString()`: an expression like `$"({firstOperand} + {secondOperand})"` is equivalent to `"(" + firstOperand.ToString() + " + " + secondOperand.ToString() + ")"`.

### Did you know?

The `Expression` and `BinaryOperation` classes above are marked as [abstract](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract) meaning that they cannot be instantiated and are only meant to be used as a base classes for others (like `Addition`, `Subtraction`, etc.) to extend.

*Abstract classes* are similar to *interfaces* and can define *abstract methods* (and properties) that extended classes <u>must</u> implement. This is similar to how *interfaces* force implementers to implement methods and properties. The main differences between *abstract classes* and *interfaces* are"
- *abstract classes* can leverage all the features of "normal" classes (like having fields and implemented properties and methods)
- a class can implement multiple *interfaces* but cannot extend more than one *abstract class* (if you want to learn more about the reason behind this limitation, investigate the [diamond problem](https://en.wikipedia.org/wiki/Multiple_inheritance#The_diamond_problem))

Because `BinaryOperation` is *abstract* and cannot be instantiated, its constructor can only be invoked by an extended class, so it can be declared as `protected`.

### Did you know?

The [switch expression](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression) (not to be confused with the [switch/case statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement)) can be a more compact alternative to using the `is` operator. You can try modifying your solution to leverage the *switch expression*.

---

Change the `Solve(Expression expression)` method above to be simply:
```
    public double Solve(Expression expression)
    {
        return expression.Solve();
    }
```

Add a `public abstract double Solve()` method to `Expression`. Implement the `Solve()` method in `Constant`, `Addition`, `Subtraction`, `Multiplication`, and `Division`.

### Did you know?

This exercise deals with a "tree of [polymorphic](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/polymorphism) objects". This means that nodes of the tree are typed as `Expression`, but will actually be of a type extending `Expression` having its own specific meaning and possibly behavior. For example, a `Constant` and an `Addition` are both `Expression` but have different fields and represent very different mathematical concepts.

When solving problems involving trees of *polymorphic* objects, it is common to implement recursive algorithms by defining one `abstract` or `virtual` method and overriding it to have different behaviors across the different types. This allows avoiding to use the `is` operator over and over to identify which type we are actually dealing with.

### Tip

Make sure to mark the `Solve()` methods in `Constant`, `Addition`, `Subtraction`, `Multiplication`, and `Division` as `override` since they *override* the `abstract` method defined in `Expression`.

You may want to learn more about `virtual`, `abstract` and `override` methods and how they are used to achieve *polymorphism*.
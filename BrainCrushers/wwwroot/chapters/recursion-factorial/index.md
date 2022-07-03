**Previous:** [Sort a list](lists-sort)

# Factorial

**Difficulty:** Very easy.

Complete the `Factorial` method below to return the [factorial](https://en.wikipedia.org/wiki/Factorial) of the input parameter. Implement `Factorial` with recursive code (see the **Did you know?** section below).

The factorial is defined as follow:
- *Factorial(0) => 1*
- *Factorial(1) => 1*
- *Factorial(n) => n·Factorial(n-1)*

Don't use any library methods.

### Did you know?

As you can see, the definition of *Factorial(n)* is based on *Factorial(n-1)*, this is called a "recursive definition". 

In order for a *recursive definition* to be usable, it must provide a "base case" that is defined non-recursively. In this case *Factorial(1)* and *Factorial(0)* are both base cases and have a known value.

Similarly, the factorial can be implemented with recursive code. A method is recursive when its body contains one or more invocations of the same method. In some cases, the recursion can be indirect: the method doesn't invoke itself but invokes other methods that in turn invoke the original method.

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester)

### Tip

Recursion is a powerful tool that can drastically reduce the amount and complexity of code. It is also easily abused and it is generally better to avoid using recursion when the problem can be solved with non-recursive code of similar complexity.

---

The `Factorial` method above can be easily implemented with a simple `for` loop and no recursion. Go back and modify the code to avoid using recursion.

---

**Next:** [Concatenate](recursion-concatenate)
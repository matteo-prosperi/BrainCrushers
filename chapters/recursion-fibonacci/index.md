**Previous:** [Math expressions](recursion-math)

# Fibonacci

**Difficulty:** Easy.

Complete the `Fibonacci` method below to return the `n`<sup>th</sup> [Fibonacci number](https://en.wikipedia.org/wiki/Fibonacci_number). Implement `Fibonacci` with recursive code.

The `n`<sup>th</sup> Fibonacci number is defined as follow:
- *Fibonacci(0) => 0*
- *Fibonacci(1) => 1*
- *Fibonacci(n) => Fibonacci(n-2) + Fibonacci(n-1)*

If the resulting number is too large to fit into a `long`, throw an `ArgumentOutOfRangeException` exception.

Don't use any library methods.

### Note

A recursive implementation of the Fibonacci sequence is very slow. It is expected for this exercise to cause a timeout when executed. We will fix this in the next portion of the exercise.

### Did you know

The Fibonacci sequence grows very rapidly. For this reason, we are using a `long` return value instead of an `int`. Even using a `long` we are only able to represent less than 100 Fibonacci numbers.

### Tip

To identify when `n` is too large for the result to fit into a `long`, you can wrap your calculations in a [checked block](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked) which will cause an `OverflowException` when the calculation causes an overflow. You can then use a [try/catch](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch) block to catch the `OverflowException` and throw an `ArgumentOutOfRangeException` instead.

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester)

### Did you know

Recursive algorithms can have very high time complexity (be very slow), if they run the recursive method many times with the same parameters. For example:
- *Fibonacci(6) => Fibonacci(4) + Fibonacci(5)*
  - *Fibonacci(4) => Fibonacci(2) + Fibonacci(3)*
      - *Fibonacci(2) => Fibonacci(0) + Fibonacci(1)*
      - *Fibonacci(3) => Fibonacci(1) + Fibonacci(2)*
        - *Fibonacci(2) => Fibonacci(0) + Fibonacci(1)*
  - *Fibonacci(5) => Fibonacci(3) + Fibonacci(4)*
    - *Fibonacci(3) => Fibonacci(1) + Fibonacci(2)*
      - *Fibonacci(2) => Fibonacci(0) + Fibonacci(1)*
    - *Fibonacci(4) => Fibonacci(2) + Fibonacci(3)*
        - *Fibonacci(2) => Fibonacci(0) + Fibonacci(1)*
        - *Fibonacci(3) => Fibonacci(1) + Fibonacci(2)*
          - *Fibonacci(2) => Fibonacci(0) + Fibonacci(1)*

As you can see above, in order to calculate *Fibonacci(6)* recursively, we need to recalculate *Fibonacci(2)* 5 times.

A common technique to address this problem is to save the result of the recursive function the first time it is calculated for a certain parameter. This technique is called *dynamic programming*.

Below you can see a *dynamic programming* optimization of the Fibonacci problem for *n>1*.

```
var sequence = new long?[n + 1];
sequence[0] = 0;
sequence[1] = 1;
try
{
    return DynamicFibonacci(n);
}
catch (OverflowException)
{
    throw new ArgumentOutOfRangeException(nameof(n));
}

long DynamicFibonacci(int n)
{
    checked
    {
        return sequence[n] ??= DynamicFibonacci(n - 2) + DynamicFibonacci(n - 1);
    }
}
```
Because with *dynamic programming* we are not recalculating the same values over and over, the execution is much faster:
- *Fibonacci(6) => Fibonacci(4) + Fibonacci(5)*
  - *Fibonacci(4) => Fibonacci(2) + Fibonacci(3)*
      - *Fibonacci(2) => sequence[0] + sequence[1]*
      - *Fibonacci(3) => sequence[1] + sequence[2]*
  - *Fibonacci(5) => sequence[3] + sequence[4]*

---

The *dynamic programming* solution shown above is actually not optimal because it has linear space complexity, which is unnecessary. 

In order to calculate *Fibonacci(n)*, you only need to know two values: *Fibonacci(n-2)* and *Fibonacci(n-1)*. A better solution is to avoid recursion altogether and simply run a `for (int i = 2; i <= n; i++)` loop, using the previous two Fibonacci numbers to calculate *Fibonacci(i)*. This allows to store only two values (constant space complexity).

Modify your code above to calculate *Fibonacci(n)* with a loop without using recursion.

---

**Next:** [Tower of Hanoi](recursion-hanoi)
**Previous:** [Print a matrix](matrices-print)

# Implement a 3x3 matrix type

**Difficulty:** Easy.

The `Matrix` class below represent a 3-by-3 *matrix* (a 2-dimensional array).

C# supports [operator overloading](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading) which can be used to implement a special behavior when an object is added, subtracted, multiplied, etc. with another. This is particularly useful when designing a type that represent a mathematical concept like a number, a vector or a matrix.

Thanks to overloaded operators, the `Matrix` class can be used like this:
```
Matrix a = new Matrix(1, 2, 3,
                      4, 5, 6,
                      7, 8, 9);
if (a * Matrix.Identity() == a) // this is always true!
{
}
```

### Did you know?

3-by-3 matrices are used in 3D software to represent a transformation (translation, scaling and rotation) in the 3-dimensional space.

### Did you know?

The [indexer](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/) for the `Matrix` class returns the element value [by reference](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/ref-returns). This is (a slightly more flexible) equivalent to providing both a *getter* and a *setter* for the *indexer*.

[](EDITABLE Using statements)
[](READONLY Intro)

Complete the `operator +` method below.

Don't use any library methods.

### Tip

You can build a `Matrix` with the desired values by starting with `Matrix.Zero()` and updating each element one by one.

### Tip

You can reference [Wikipedia](https://en.wikipedia.org/wiki/Matrix_(mathematics)) for the formulae of matric operations.

[](READONLY Addition Intro)
[](EDITABLE Addition)
[](READONLY Addition Outro)
[](RUN BrainCrushersTests.TesterAddition)

---

Complete the `operator -` method below.

[](READONLY Subtraction Intro)
[](EDITABLE Subtraction)
[](READONLY Subtraction Outro)
[](RUN BrainCrushersTests.TesterSubtraction)

---

Complete the `operator *` method below.

[](READONLY Multiplication Intro)
[](EDITABLE Multiplication)
[](READONLY Multiplication Outro)
[](RUN BrainCrushersTests.TesterMultiplication)

---

Complete the `operator *` method below implementing the multiplication of a `Matrix` with a size-3 column vector.

[](READONLY Matrix-Vector Multiplication Intro)
[](EDITABLE Matrix-Vector Multiplication)
[](READONLY Matrix-Vector Multiplication Outro)
[](RUN BrainCrushersTests.TesterVectorMultiplication)

---

### Did you know?

Because the `Matrix` class represents a "value" and different `Matrix` objects may "be equal" (have the same value), we should override the [Equals(object? obj)](https://docs.microsoft.com/en-us/dotnet/api/system.object.equals) method.

Whenever we override the `Equals` method, we also **must** override the [GetHashCode()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode) method that is used to optimize checks for equality and to implement [hash tables](https://en.wikipedia.org/wiki/Hash_table). Whenever two objects of the same type are equal (`Equals` returns `true`) the `GetHashCode` method **must** return the same value for both of them.

When overriding `Equals(object? obj)`, it is also a best practice to implement [IEquatable<T>](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1). If the objects are also sortable, we should also implement [IComparable<T>](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1), but matrices are not sortable, so this doesn't apply here.

Because we have implemented mathematical operators for `Matrix`, we should also implement the `operator ==` to behave in the same way as `Equals(Matrix? other)`.

Whenever we implement the `operator ==`, we also **must** implement the `operator !=`. If the objects are also sortable, we can also consider implementing *all* the comparison operators (`<`, `<=`, `>`, and `>=`).

When implementing `Equals` and operators for reference types, it is important to be careful that `null` values are handled correctly!

[](READONLY Outro)

---

**Next:** [Convert an array to a linked list and back](lists-arrayToList)
**Previous:** [Calculate array rotation](arrays-getRotation)

# Sort an array

**Difficulty:** Easy.

The `Sort` method below takes an array of integers as parameter.

Complete the code of the `Sort` method to order the elements of the array from the smallest to the largest. DO NOT use any library method like `Array.Sort` or `Enumerable.OrderBy`.

[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

Press the button below to test your solution

[](RUN BrainCrushersTests.Tester)

---

Try implementing [selection sort](https://en.wikipedia.org/wiki/Selection_sort) and [bubble sort](https://en.wikipedia.org/wiki/Bubble_sort).

*Selection sort* is probably the most intuitive sorting algorithm.

*Bubble sort* is still very simple, faster when the array is already partially sorted, and *stable* (a sorting algorithm is *stable* when it maintains the relative position of elements with the same value).

Both algorithms have the same time complexity of *n<sup>2<sup>* and work *in place* (meaning that they don't require copying data to temporary arrays or other data structures, this is also called "having a constant space complexity").

### Did you know?

*Selection sort* requires repeating the same operation on a smaller and smaller subset of the array: each round only the unsorted portion of the array is considered and the smallest value is moved to the first position which shrinks the unsorted portion.

Using the [Span](https://docs.microsoft.com/en-us/dotnet/api/system.span-1) type, which represents a subset of an array, allows reducing the amount of indexes that is necessary to juggle making the code simpler and easier to write.

```
Span<int> unsorted = data;
while (unsorted.Length > 1)
{
    MoveSmallestToTheBeginning(unsorted);
    unsorted = unsorted.Slice(start: 1);
}
```

---

**Difficulty:** Hard.

Implement [merge sort](https://en.wikipedia.org/wiki/Merge_sort).

*Merge sort* is a recursive algorithm and leverages the solution of the [Merge arrays](arrays-merge) exercise. *Merge sort* has time complexity of *n·log<sub>2</sub>(n)* which is ideal. It requires a temporary storage for the entire content of the array, which results in the algorithm having linear space complexity.

### Tip

Using [Span](https://docs.microsoft.com/en-us/dotnet/api/system.span-1) drastically simplifies the code of a *merge sort* implementation.

### Tip

Create separate private methods to keep the implementation clean and readable.

---

**Next:** [Find the best historical time to buy and sell stocks](arrays-buySell)
**Previous:** [*binary search tree*s](binTrees-bst)

# Binary search trees, read operations

**Difficulty:** Easy.

Complete the `Find` method below returning the tree node with the specified value, if present. `root` is the *root* node of a *binary search tree* with no duplicated values.

You can use library methods.

### Tip

Exploring a *binary search tree* doesn't require recursion.

[](EDITABLE Using statements)
[](READONLY Intro 1)
[](EDITABLE Solution 1)
[](READONLY Outro 1)

[](RUN BrainCrushersTests.Tester1)

---

Complete the `FindAll` method below returning all tree nodes with the specified value. `root` is the *root* node of a *binary search tree* which may include duplicated values.

### Tip

You can consider using [yield](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/yield) to implement a method that returns an [IEnumerable`<T`>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1).

[](READONLY Intro 2)
[](EDITABLE Solution 2)
[](READONLY Outro 2)

[](RUN BrainCrushersTests.Tester2)

---

Complete the `FindMin` method below returning the smallest value of the *binary search tree* passed as parameter. Return `null` if the tree is empty.

[](READONLY Intro 3)
[](EDITABLE Solution 3)
[](READONLY Outro 3)

[](RUN BrainCrushersTests.Tester3)

# Did you know?

A *binary search tree* is an extremely efficient and flexible data structure. It allows:
- finding a value,
- removing a value,
- adding a value,
- and finding the smallest or largest value,

all with *log<sub>2</sub>(n)* complexity, as long as the tree is reasonably balanced.

Self-balancing variants of a *binary search tree* like the [red–black tree](https://en.wikipedia.org/wiki/Red-black_tree) even guarantee that the tree always stay balanced while inserting and removing values.

If you only need a data structure that allows:
- finding the smallest value (*peek*),
- removing the smallest value (*pop*),
- and adding a value,

a [min heap](https://en.wikipedia.org/wiki/Heap_(data_structure)) is even more efficient, allowing to run the *peek* operation in constant time and still providing *log<sub>2</sub>(n)* time complexity for the others.

---

**Next:** [Binary Search Trees, write operations](binTrees-bstWrite)
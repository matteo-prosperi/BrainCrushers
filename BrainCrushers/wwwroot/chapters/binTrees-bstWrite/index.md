**Previous:** [Binary Search Trees, read operations](binTrees-bstRead)

# Binary search trees, write operations

**Difficulty:** Easy.

Complete the `Add` method below adding `value` to the *binary search tree*.

You can use library methods.

### Tip

The *binary search tree* can contain duplicates.

[](EDITABLE Using statements)
[](READONLY Intro 1)
[](EDITABLE Solution 1)
[](READONLY Outro 1)

[](RUN BrainCrushersTests.Tester1)

### Did you know?

A simple implementation of the Add and Remove operations on a *binary search tree* will leave the tree in a highly unbalanced state for certain sequences of operations, like repeatedly adding values that are sorted. Self-balancing variants of a *binary search tree* like the [red–black tree](https://en.wikipedia.org/wiki/Red-black_tree) avoid this problem but are too complex to implement in the time available during a coding interview.

---

**Difficulty:** Medium.

Complete the `Remove` method below removing `value`, if present, from the *binary search tree*.

You can use library methods.

[](READONLY Intro 2)
[](EDITABLE Solution 2)
[](READONLY Outro 2)

[](RUN BrainCrushersTests.Tester2)

---

**Next:** [Create a binary search trees from a sorted array](binTrees-bstFromSortedArray)
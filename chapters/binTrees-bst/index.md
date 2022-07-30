**Previous:** [Convert a binary tree to a list](binTrees-toList)

# Binary Search Trees

**Difficulty:** Easy.

A *binary search tree* (sometimes abbreviated *BST*) is a binary tree where each node has a greater or equal value than all nodes in the left subtree and a lesser value than all nodes in the right subtree.

One of the properties of a *binary search tree* is that, when traversed *in order*, the nodes of tree are encountered sorted from the smallest to the largest.

*Binary search trees* are commonly used to store sorted values because you can execute [binary search](https://en.wikipedia.org/wiki/Binary_search_algorithm) on them (hence the name) but allow more efficient insertion and removal operations compared to an array.

Complete the `IsBst` method below returning if the tree passed as parameter is a *binary search tree* or not. The input tree doesn't have any duplicate values.

You can use library methods.

[](EDITABLE Using statements)
[](READONLY Intro 1)
[](EDITABLE Solution 1)
[](READONLY Outro 1)

[](RUN BrainCrushersTests.Tester1)

---

Update the `IsBst` method above to be able to evaluate trees with duplicate values.

[](RUN BrainCrushersTests.Tester2)

---

In order to be able to run *binary search* efficiently on a *binary search tree*, the tree must be *balanced*.

A tree is unbalanced when some branches have very different depth than others.

For example, the following *binary search tree* is very unbalanced: if I were searching for value `0`, I would have to traverse all but one node.
```
    [5]
    /
  [0]
    \
    [3]
    / \
  [2] [4]
  /
[1]
```
The *binary search tree* below is an optimally balanced version of the above tree: I am able to find any node in the tree traversing at most three nodes (which is *log<sub>2</sub>(n)* where *n* is the number of nodes in the tree).
```
      [3]
     /   \
  [1]     [5]
  / \     /
[0] [2] [4]
```

Update the `IsBalanced` method below to return whether the tree passed as parameter is balanced. For the sake of this exercise, we define *balanced* as having the minimum possible depth (the deepest branch is at most 1 level deeper than the most shallow one).

[](READONLY Intro 2)
[](EDITABLE Solution 2)
[](READONLY Outro 2)

[](RUN BrainCrushersTests.Tester3)

---

**Next:** [Traverse a maze](misc-maze)
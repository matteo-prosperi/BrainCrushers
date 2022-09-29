**Previous:** [Tower of Hanoi](recursion-hanoi)

# Count and depth of a binary tree

**Difficulty:** Very easy.

Complete the `Count` method below counting the nodes of the [binary tree](https://en.wikipedia.org/wiki/Binary_tree) passed as input.

Don't use any library method.

### Did you know?

Binary trees are data structures similar to linked lists. While a linked list node contains a single reference to the next node, a binary tree contains two references to its children node: the left child and the right child. Similarly to linked lists, each node also has a value. One node can have either the left or right (or both) children references set to `null`.

Given the following tree,
```
    [3]
    / \
[1]     [5]
  \     / \
  [2] [4] [6]
```
the node `3` is called the *root*. `1` is the left child of `3` and `5` is the right one. `1` and `2` are the left descendants of `3`. The node `1` has a `null` left reference (no left child).

In the same way as you can pass a linked list as a method parameter by passing a reference to its *head*, you can pass a binary tree by passing a reference to its *root*.

Navigating from one node to another in a tree is called "traversing" the tree.

### Did you know?

A binary tree is called "binary" because each node has exactly two children.

A "tree" (non-binary) more generally can have nodes with a variable number of children:
```
     [3]
    / | \
[1]  [7]  [5]
  \      / | \
  [2] [4] [9] [6]
```

A tree is a specialized form of a "graph" in which cycles between nodes are not allowed. The following graph is NOT a tree:
```
   [3]
  /   \
[1]   [5]
  \   / \
   [4]   [6]
```

### Tip

Algorithms traversing binary trees are usually implemented recursively.

[](EDITABLE Using statements)
[](READONLY Intro 1)
[](EDITABLE Solution 1)
[](READONLY Outro 1)

[](RUN BrainCrushersTests.Tester1)

---

Now complete the `Depth` method below counting how many rows the binary tree has.

Don't use any library method.

[](READONLY Intro 2)
[](EDITABLE Solution 2)
[](READONLY Outro 2)

[](RUN BrainCrushersTests.Tester2)

---

**Next:** [Convert a binary tree to a list](binTrees-toList)
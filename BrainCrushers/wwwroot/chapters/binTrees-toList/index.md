**Previous:** [Count and depth of a binary tree](binTrees-countAndDepth)

# Convert a binary tree to a list

**Difficulty:** Easy.

Complete the `TreeToLists` method below converting the input binary tree to three lists:
- the first list should contain all node values in *pre-order*,
- the second list should contain all node values *in order*,
- the second list should contain all node values in *post-order*.

Don't use any library method.

### Did you know?

*Pre-order* means that a node is evaluated before its children. *Post-order* means that a node is evaluated after its children. *In oder* means that a node is evaluated after its left child before its right child.

Given the following tree,
```
    [3]
    / \
[1]     [5]
  \     / \
  [2] [4] [6]
```
it's nodes are:
- in *pre-order* `[3 1 2 5 4 6]` (3 is first because it is listed before its descendants, 1 and 5 also appear before their own descendants)
- *in order* `[1 2 3 4 5 6]`
- in *post-order* `[2 1 4 6 5 3]` (3 is last because it is listed after its descendants, 1 and 5 also appear after their own descendants)

A binary tree is sorted when the values of the left descendants of a node are all smaller than the value of the node itself; the values of the right descendants of a node are all larger than the value of the node itself. Because the above tree is sorted, its nodes, when represented *in order*, are sorted from the smallest to the largest.

[](EDITABLE Using statements)
[](READONLY Intro 1)
[](EDITABLE Solution 1)
[](READONLY Outro 1)

[](RUN BrainCrushersTests.Tester1)

---

**Difficulty:** Medium.

Now complete the `BreadthFirstToList` method below converting the input converting the input binary tree to a list using in [breadth-first](https://en.wikipedia.org/wiki/Breadth-first_search) order.

Don't use any library method.

### Did you know?

*Breadth-first* traversal of a tree means that nodes are evaluated row by row from the left to the right, a row is evaluated fully before moving to the next.

For example, the tree from the example above would be listed *breadth-first* as `[3 1 5 2 4 6]`.

### Tip

*Breadth-first* traversal is usually implemented by temporary storing references to the nodes in the next row in a list.

[](READONLY Intro 2)
[](EDITABLE Solution 2)
[](READONLY Outro 2)

[](RUN BrainCrushersTests.Tester2)

---

**Next:** [Traverse a maze](misc-maze)
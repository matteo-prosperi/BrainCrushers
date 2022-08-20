**Previous:** [Create a binary search trees from a sorted array](binTrees-bstFromSortedArray)

# Top view of a binary tree

**Difficulty:** Medium.

Complete the `TopView` method below converting the input *binary tree* to its "top view".

We define "top view" of a *binary tree* as the list of the topmost nodes of the tree for each value of "horizontal position", ordered by the "horizontal position" value.

Given a node with "horizontal position" *x*, its right child has "horizontal position" *x+1* and its left child has "horizontal position" *x-1*. The *root* of the tree has "horizontal position" *0*.

For example, we can analyze the following *binary tree*.

```
    [3]
    / \
[1]     [5]
  \     / \
  [2] [4] [6]
        \
        [7]
          \
          [8]
            \
            [9]
```
The following diagram shows the "horizontal position" of each node.
```
    #0
    [3]
    / \
#-1     #1
[1]     [5]
  \     / \
  #0  #0  #2
  [2] [4] [6]
        \
        #1
        [7]
          \
          #2
          [8]
            \
            #3
            [9]
```
The "top view" of the *binary tree* is the following: for each "horizontal position", from *-1* to *3*, we take the topmost node.
`[1, 3, 5, 6, 9]`

You can use library methods.

### Tip

During an interview, the interviewer is likely not to provide a clear definition of "top view" with the expectation that the candidate will ask questions to clarify the problem before starting to write code.

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester)

---

This is a very interesting problem because it can be solved in many different ways depending on what you are optimizing for:
- Can you write a very compact solution leveraging [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-to-objects)?
- Can you write a solution that leverages *breadth-first search*?
- Can you write a solution that doesn't allocate any data structure except for the output array?

What is the time and space complexity of each of your solution when the *binary tree* is balanced?

What if the interviewer asked for the "bottom view" instead of the "top view" of the *binary tree*?

---

**Next:** [Traverse a maze](misc-maze)
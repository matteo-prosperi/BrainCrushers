**Previous:** [Implement a 3x3 matrix type](matrices-operations)

# Row with most true values

**Difficulty:** Medium.

Complete the `FirstMostTrue` method below to return the index of the row with the most `true` values in the `data` 2D array. Each row of the `data` array is a sequence of 0 or more `true` values followed by `false` value. In case there are multiple rows having the maximum number of `true` values, return the index of the first one.

For example, given the following input `FirstMostTrue` should return 2.
```
[ true  true  false false]
[ true  false false false]
[ true  true  true  true ] // Row 2 is the first with the most true values
[ false false false false]
[ true  true  true  true ]
```

Don't use any library methods.

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester)

---

Can you optimize your solution so that it has time complexity *h·log<sub>2</sub>(w)* where *h* is the number of rows and *w* is the number of columns of `data`?

---

**Next:** [Convert an array to a linked list and back](lists-arrayToList)
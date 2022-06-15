**Previous:** [Maximum average of increasing sequence](arrays-maxAverageOfIncreasingSequence)

# Find a value

**Difficulty:** Very easy.

Complete the `FindValue` method below to return the position of `value` in the sorted array `data`. Return -1 if `value` cannot be found in the array.

Don't use library methods.

[](EDITABLE Using statements)
[](READONLY Intro)
[](EDITABLE Solution)
[](READONLY Outro)

[](RUN BrainCrushersTests.Tester1)

---

**Difficulty:** Easy.

Update the code above to have maximum time complexity *log2(n)*. This means completing the find operation without reading more than *log2(n) + 1* array elements. This can be achieved because the elements in the array are sorted: you can check the item at the center of the array, which will allow you to know on which side of the array `value` is (on the right side if `value` is greater than the element at the center, otherwise on the left). Continue splitting the array in smaller and smaller halves until you find `value`. This is called "binary search".

[](RUN BrainCrushersTests.Tester2)

---

**Next:** [Sort an array](arrays-sort)
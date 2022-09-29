**Previous:** [Row with most true values](matrices-mostTrues)

# Convert an array to a linked list and back

**Difficulty:** Very easy.

Complete the `ArrayToList` method below converting the input array to a [linked list](https://en.wikipedia.org/wiki/Linked_list) and return the head of the list or `null` if the array is empty.

Don't use any library method.

### Did you know?

The first node of a linked list (the one that can be used to iterate all other nodes) is called "head". The last node (the one that contains a `null` reference) is called tail.

Sometimes code that uses lists defines or uses a class that implements the linked list data structure, like [LinkedList\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1), other times the *head* node is simply used to represent the whole list.

### Did you know?

`Node` in the code below is a *reference type* (a `class`), so variables (and fields, properties, parameters, and return values) of type `Node` can always be null. We can use the `Node?` as a reminder that a variable of type `Node` can reasonably be `null`. This C# feature is called [nullable reference types](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references). It's important to remember that not having specified `?` doesn't provide any guarantee that a *reference type* variable, field, property, parameter, or return value is not `null`.

[](EDITABLE Using statements)
[](READONLY Intro 1)
[](EDITABLE Solution 1)
[](READONLY Outro 1)

[](RUN BrainCrushersTests.Tester1)

---

**Difficulty:** Very easy.

Now complete the `ListToArray` method below converting the input linked list into an array.

Don't use any library method.

[](READONLY Intro 2)
[](EDITABLE Solution 2)
[](READONLY Outro 2)

[](RUN BrainCrushersTests.Tester2)

---

**Next:** [Linked list operations](lists-operations)
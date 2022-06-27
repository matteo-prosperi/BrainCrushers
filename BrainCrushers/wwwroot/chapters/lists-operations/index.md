**Previous:** [Convert an array to a linked list and back](lists-arrayToList)

# Linked list operations

**Difficulty:** Easy.

Complete the `MyList` class below implementing a linked list.

Don't use any library method.

### Did you know?

When implementing a data structure, it is a good practice to implement one or more of the standard `System.Collections.Generic` interfaces in order to provide a familiar set of methods (as well as leverage existing C# features like [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-to-objects)).

In this case we are implementing [IList\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1) which offers index-based operations and implies [ICollection\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1) (supports `Count`, `Add`, `Remove`, `Clear` and `Contains`) and [IEnumerable\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) (supports `foreach` and *LINQ*).

We are implementing `IList<T>` because we want to practice a variety of linked lists algorithms. In real life we would probably avoid implementing `IList<T>` and only implement `ICollection<T>` (which implies `IEnumerable<T>`) because we don't want to incentivize our users to do index-based operations which are inefficient on linked lists.

### Did you know?

We are using a public interface `INode` and a private class `Node` because we don't want our users to directly modify `Next` and `Value`.

[](EDITABLE Using statements)
[](READONLY Intro)

Complete the `AddAsHead` method which adds a new node to the beginning of the list.

### Tip

Don't forget to keep the `Count` property updated when modifying the list.

[](READONLY AddAsHead Intro)
[](EDITABLE AddAsHead)
[](READONLY AddAsHead Outro)

[](RUN BrainCrushersTests.AddAsHeadTester)

Complete the `RemoveHead` method which removes the value at the beginning of the list and returns it to the caller. Throw an [InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) if the list is empty.

[](READONLY RemoveHead Intro)
[](EDITABLE RemoveHead)
[](READONLY RemoveHead Outro)

[](RUN BrainCrushersTests.RemoveHeadTester)

Complete the `AddAsTail` method which adds a new node to the end of the list.

[](READONLY AddAsTail Intro)
[](EDITABLE AddAsTail)
[](READONLY AddAsTail Outro)

[](RUN BrainCrushersTests.AddAsTailTester)

Complete the `RemoveTail` method which removes the value at the end of the list and returns it to the caller. Throw an [InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) if the list is empty.

[](READONLY RemoveTail Intro)
[](EDITABLE RemoveTail)
[](READONLY RemoveTail Outro)

[](RUN BrainCrushersTests.RemoveTailTester)

Complete the `Clear` method which removes all items from the list.

### Tip

This method can be implemented in just two statements 😉.

[](READONLY Clear Intro)
[](EDITABLE Clear)
[](READONLY Clear Outro)

[](RUN BrainCrushersTests.ClearTester)

Complete the `Find` method which finds the first node with the provided value and returns it. Return `null` if the value is not found.

### Did you know?

`ICollection<T>` requires implementing the `Contains` method but having a `Find` method makes more sense for a linked list. As you can see below `Contains` can be implemented as a simple variation of `Find`.

[](READONLY Find Intro)
[](EDITABLE Find)
[](READONLY Find Outro)

[](RUN BrainCrushersTests.FindTester)

Complete the `GetNodeAt` method below returning the node at a given position in the list. Return `null` if list is too short.

### Did you know?

[indexers](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/) allow accessing the content of your class with the `[]` operator, similarly to how you access elements of an array. As you can see below, it is easy to implement *indexers* for a linked list leveraging the `GetNodeAt` method.

### Did you know?

The [null-conditional operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-) `?.` and [null-coalescing operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator) `??` can be used to quickly and correctly handle `null` values avoiding [NullReferenceExceptions](https://docs.microsoft.com/en-us/dotnet/api/system.nullreferenceexception).

[](READONLY GetNodeAt Intro)
[](EDITABLE GetNodeAt)
[](READONLY GetNodeAt Outro)

[](RUN BrainCrushersTests.GetNodeAtTester)

Complete the `IndexOf` method below returning the first index for a given value or -1 if the value is not found.

[](READONLY IndexOf Intro)
[](EDITABLE IndexOf)
[](READONLY IndexOf Outro)

[](RUN BrainCrushersTests.IndexOfTester)

Complete the `InsertAfter` method below which adds a the provided value to the list after the provided node. Insert the value as the new head if `node` is `null`.

[](READONLY InsertAfter Intro)
[](EDITABLE InsertAfter)
[](READONLY InsertAfter Outro)

[](RUN BrainCrushersTests.InsertAfterTester)

Complete the `Insert` method below which adds a the provided value at the specified position of the list. Throw an [ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception) if the list is too short.

[](READONLY Insert Intro)
[](EDITABLE Insert)
[](READONLY Insert Outro)

[](RUN BrainCrushersTests.InsertTester)

Complete the `Remove` method below which removes the first occurrence of the provided value. Returns whether the value was found and removed.

[](READONLY Remove Intro)
[](EDITABLE Remove)
[](READONLY Remove Outro)

[](RUN BrainCrushersTests.RemoveTester)

Complete the `RemoveAt` method below which removes the node at the specified position. Throw `ArgumentOutOfRangeException` if the list is too short.

[](READONLY RemoveAt Intro)
[](EDITABLE RemoveAt)
[](READONLY RemoveAt Outro)

[](RUN BrainCrushersTests.RemoveAtTester)

### Did you know?

C# provides the [yield](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/yield) functionality to easily create an `IEnumerable<T>` from iterative code (like a `while` loop).

### Did you know?

`Enumerate` in the code below is a [local function](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions). *Local functions* can be used to organize your code in functions without creating unnecessary private methods when the code in question is used from within a single method. In this case, we need to enclose the iterative code in a function in order to leverage the `yield` functionality.

[](READONLY GetEnumerator)

[](READONLY CopyTo)

### Did you know?

Sometimes implementing an interface requires you to implement a method or property that you would rather not expose to your users. [Explicit interface implementations](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/explicit-interface-implementation) allow you to implement such methods (or properties) without making them public on your class. A user would be able to use an explicit implementation only when explicitly casting an instance of your class to the correct interface.

For example, the `Add` method below adds an element to the beginning of the list (because it would be inefficient to add it to the end of a linked list). A user could mistakenly expect that the new item is added to the end. For this reason, we rather guide the user to explicitly call `AddAsHead` or `AddAsTail` by hiding the `Add` method.

Explicit implementations are also needed when two interfaces require to implement methods with the same name and parameters but different return values. In this case, we have to implement explicitly at least one of `IEnumerable.GetEnumerator()` and `IEnumerable<T>.GetEnumerator()`. We chose to implement explicitly `IEnumerable.GetEnumerator()` because `IEnumerable` is an outdated interface.

[](READONLY Explicit implementations)
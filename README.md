# LINQ

Repository to practice LINQ

## What is LINQ (Language Integrated Query)?

Is a set of technologies that allow simple and efficient querying over differtent kinds of data.

LINQ is able to work with other things than Arrays or List, like Databases, XML files,

## Benefits of LINQ

- It allows a simple, efficient and unified way of queryying over different types of data
- Queries are execute only when the result is needed
- Code written with LINQ is cleaner, more readable and shorter

## What is Lambda expressions?

These expressions are part of C# and are used to create anonymous functions.
The sintaxis of a lambda expression is the following:

OneLineFunction

**(input params)** + **(lambda declaration operator)** => + **(result of the function)**

MoreLinesFunction

**(input params)** + **(lambda declaration operator)** => + { return **(result of the function)**}

## LINQ and ExtensionMethods

### What is an ExtensionMethod?

Is a method defined outside of a type, that can be called upon this type's objects as a regular member
method. Extension methods allow us to add new functionality to a type without modifying it.

## LINQ and IEnumerable<T>

IEnumerable<T> is an interface implemented by most of the collections (Arrays, Lists, HashSets and Dictionaries).
This interface enables iterating a collection with a foreach loop. If a type doesnnt implement this interface
it's not possible to iterate it with a foreach loop.

_Most of the LINQ's methods are extension methods for IEnumerable<T>_

IEnumerable doesn't expose any methods for collection modification. **This means LINQ methods will never modify
the input collections**.
The **Append** method actually doesn't modify the collection, it creates another one with the new element instead

There are more LINQ methods that creates a new collection like: Where, OrderBy.

### Chaining methods

There are some methods that produce a new IEnumerable<T> as result, we can chaining LINQ methods using this
feature. I mean we can execute a Where operation and with that result execute a OrderBy operation inmediatly
and in the same line of code.

## Deferred Execution

This kind of execution means:
* That the evaluation of a LINQ expression is delayed until the value is actually needed.
* It improves the performance by avoiding unnecessary execution/materialization.
* Allow us to work with the latest data


Knowing about how LINQ truly works when it comes to bigger chains is an amazing piece of knowledge which immensely
helps when it comes to performance estimations & optimizations.

If I had to mention two things to take away from this post:

- Imagine LINQ to work like a continuous stream instead of a monstrosity which constantly enumerates your source sequence.
- Be thoughtful when and where to materialize your LINQ queries. Lots of .ToList() calls cause a lot of potentially unnecessary materialization.

## Method Syntax vs Query Syntax

### Method Syntax
#### Advantages
* It's pure C#
#### Disadvantages


### Query Syntax
#### Advantages
* Easy to learn if you know SQL
* Some operations are simple to write when we using it (like Join operation)
#### Disadvantages
* Has a new "language" to learn
* Not all LINQ operations are supported (like Distinct operation) and at the end we will need apply method syntax
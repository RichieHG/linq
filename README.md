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


## All Method
This method returns **true** if we apply it in **Empty Collections**. Also, the lambda passed as an argument will never be executed (because it's executed for each element of the collection, but there are none)

## Count and LongCount
We have to use LongCount when we expect a result larger than the maximim value of ***int (2,147,483,647)*** and this method will return a long instead a int.

## Contains
In some cases we will need to declare a *comparer* (using *IEqualityComparer* as base interface) to be more explicit how we can make the comparison between objects. Remember as default config Contains uses the objects by references.

## OrderBy | OrderByDescending | ThenBy | ThenByDescending | Reverse
This methos always (when it would not be Descending) will order your collection from smallest to largest.

For simple types we have to use the main object of our OrderBy method as our orderKey, it looks like
```numbers.OrderBy(number => number)```

If we have to chaining more than one ordering (multiple ordering criteria), we can use **ThenBy** or **ThenByDescending** to do that.

We can create our own comparer to create more specific ordering (using *IComparer* as base interface)

*Reverse* method as it's name said, reverse the order of our collection.

**NOTE**:
In C# when ordering a collection by a boolean variable, the false values come before true values. For example:

``` 
var bools = new[] { true, false, true };
var orderedBools = bools.OrderBy(b => b);
```
Produce this output: `{false, true, true}`

For these reason you have to think in your boolean expression like in a mirror, it means, write your validation thinking your expected value has a FALSE result. Otherwise you will have to use DESCENDING methods and write your validation expecting a TRUE result.

## MinMax
If we want to create a custom *comparer* to MinMax methos we have to implement the *IComparable* interface in our main class.

For *Non-nullable types* MinMax methods will throw a Exception if the collection is empty

For *Nullable types* MinMax methods will return a *null* if the collection is empty

## Average
This method only works with numbers or selectors with a numeric type.

If we apply Average to an empty collection, we will receive an Exception
 ## Null-Coalescing (??)
 If we want to evaluate if a object is null to use another one, we can use Conditional Operator (? :) and we would have something like
 ```
 valueToEvaluate != null ? valueToEvaluate : alternativeValue
 ``` 

 But we also do this easier using the Null-Coalescing operator (??) and our last code would look like:

 ```
 valueToEvaluate ?? alternativeValue
 ```

 ## Sum
This method only works with numbers or selectors with a numeric type.

If we apply Sum to an empty collection, we will receive a Zero as result.

## First and Last
This methos will throw an exception if the collection is empty or any element match with the predicate.

To avoid this exception we can use FirstOrDefault / LastOrDefault methods that can handle an empty collection or a non matches returned the default value for the collection.

## Single
This method is like First or Last methods, but it's a singularity, if in the collection there are more than ONE element which matches which the predicate, SingleMethod will throw an Exception. 

Also it will do the same if any element matches. To avoid this behaviour we can use SingleOrDefault to receive the default value.

## Where
This method has an overload, which receive as parameter an integer which would be take as the INDEX (position into the collection) of the element that is being analyzing

## Take
This method is commonly used with Ordered Collections to improve the performance of the query.

## OfType 
This method filters an Enumarable according the type defined into the call.

We can use it when we have many types of objects that share the same interface

## Distinct
In some cases we will need to declare a *comparer* (using *IEqualityComparer* as base interface) to be more explicit how we can make the comparison between objects. Remember as default config Contains uses the objects by references.

## Concat
This methos is used to *concatenate* 2 collections of the same type. **Doesn't Remove Duplicates** 

## Union
 This methos is used to *concatenate* 2 collections of the same type. **Remove Duplicates** 

 ## ToHashSet 
 A HashSet is a collecton that enforce the elements to be unique.
 
 Using this method we will transform our Collecton to HashSet, it means, the new collection will no contain duplicates.

 ## ToDictionary
 A Dictionary s a collection of Key-Value pairs, each Key is **unique**. For this reason if you will use ToDictionary method you have to defined a KEY that always be unique, this to avoid exceptions in you program.

This method will crate a Dictionary of our collection. To do this we have to defined which data will be used as KEY and which other will be the VALUE. But also, we can skip the VALUE definition, and C# will understand the value is the whole object.

## ToLookup
A Lookup works similary as a Dictionary, but it allows you to save multiple values under the same Key. But also the KEY must be unique. But also, we can skip the VALUE definition, and C# will understand the value is the whole object.

## AsEnumerable
This method change a specific type of Collection to a IEnumerable<T> Collection and now we can use the other methods with this new Collection.




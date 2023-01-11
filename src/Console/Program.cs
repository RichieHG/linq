﻿using Exercises;
using LinqCourse;
using LinqCourse.DataTypes;
using Utilities;

namespace ConsoleSample
{
    public static class Extensions
    {
        public static int GetCountOfLines(this string input)
        {
            return input.Split("\n").Length;
        }

        public static IEnumerable<TResult> OurSelectMany<TSource, TResult>(
           this IEnumerable<TSource> source,
           Func<TSource, IEnumerable<TResult>> selector)
        {
            var results = new List<TResult>();
            foreach (var element in source)
            {
                var innerCollection = selector(element);
                foreach (var innerElement in innerCollection)
                {
                    results.Add(innerElement);
                }
            }
            return results;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public Person(string _name, string _country)
        {
            Name = _name;
            Country = _country;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //METHOD SYNTAX

            //All.Run();
            //Count.Run();
            //Contains.Run();
            //OrderBy.Run();
            //MinMax.Run();
            //Average.Run();
            //Sum.Run();
            //ElementAt.Run();
            //FirstLast.Run();
            //SingleElement.Run();
            //Where.Run();
            //Take.Run();
            //Skip.Run();
            //OfType.Run();
            //Distinct.Run();
            //PrependAppend.Run();
            //ConcatUnion.Run();
            //TypeSwitching.Run();           
            //Select.Run();
            //SelectMany.Run();
            //GeneratingNewCollection.Run();
            //GroupBy.Run();
            //IntersectExcept.Run();
            //Joins.Run();
            //Aggregate.Run();
            //Zip.Run();

            //QUERY SYNTAX

            //OrderBy.QuerySyntax.Run();
            //Where.QuerySyntax.Run();
            //Select.QuerySyntax.Run();
            //SelectMany.QuerySyntax.Run();
            //GroupBy.QuerySyntax.Run();
            //Joins.QuerySyntax.Run();

            //OTHERS
            //DotNet6Improvements.Run();

            var numbers = new[] { 1, 4, 10, 154, 999, 15 }; //{ 16, 8, 9, -1, 2 }; //new[] { 1, 4, 3, 99, 256, 2 };
            var words = new[] { "a", "bb", "ccc", "dddd" };
            var pets = Data.Pets;

            #region Introduction to LINQ
            //var wordsNoUpperCase = new string[] {
            //    "quick", "brown", "fox"
            //};
            ////Console.WriteLine(IsAnyWordUpperCase(wordsNoUpperCase));    
            //Console.WriteLine(IsAnyWordUpperCase_LINQ(wordsNoUpperCase));
            //var wordsWithUpperCase = new string[] {
            //    "quick", "brown", "FOX"
            //};
            ////Console.WriteLine(IsAnyWordUpperCase(wordsWithUpperCase));
            //Console.WriteLine(IsAnyWordUpperCase_LINQ(wordsWithUpperCase));

            //var orderedWords = wordsNoUpperCase.OrderBy(word => word);
            #endregion

            #region Introduction to Lambda Expressions
            //bool isAnyLargerThan100 = IsAny(numbers, number => {
            //    const int max = 100;
            //    return number > max;
            //});
            //Console.WriteLine($"Is any > 100?: {isAnyLargerThan100}");

            //Func<int, bool> isEven = number => number % 2 == 0;
            //bool isAnyEven = IsAny(numbers, isEven );
            //Console.WriteLine($"Is any even?: {isAnyEven}");


            //var words = new[] { "aaa", "bbbb", "cc" };
            //bool isAnyOfLength4 = IsAny(words, word => word.Length == 4);
            //Console.WriteLine($"Is any word length == 4?: {isAnyOfLength4}");

            #endregion

            #region LINQ and ExtensionMethods
            //var words = new List<string>() { "a", "bb", "ccc", "dddd" };
            //var wordsLongerThan2Letters = words.Where(word => word.Length > 2);
            //Console.WriteLine(string.Join(", ", wordsLongerThan2Letters));

            //var multiLineString = @"
            //Please give me a ride on your back,
            //Said the duck to the kangaroo:
            //I would sit quite still, and say nothing but 'quack'
            //The whole of the long day through;
            //And we'd go the Dee, and the Jelly Bo Lee,
            //Over the land, and over the sea:
            //Please take me a ridde! oh, do!
            //Said the duck to the kangaroo.";

            //var countOfLines = multiLineString.GetCountOfLines();
            //Console.WriteLine($"This paragraph {multiLineString} \n has {countOfLines} lines");
            #endregion

            #region LINQ and IEnumerable<T>
            //numbers = new List<int> { 5, 3, 7, 1, 2, 4 };
            //var numnerswith10 = numbers.Append(10);

            //Console.WriteLine("Numbers: " + string.Join(", ", numbers));
            //Console.WriteLine("Numbers with 10 : " + string.Join(", ", numnerswith10));

            ////var oddNumbers = numbers.Where(number => number % 2 == 1);
            //var orderedOddNumers = numbers
            //    .Where(number => number % 2 == 1)
            //    .OrderBy(number => number);
            //Console.WriteLine("Odd Numbers: " + string.Join(", ", orderedOddNumers));
            #endregion

            #region DeferredExecution
            //var shortWords = words.Where(word => word.Length < 3);
            //Console.WriteLine("First iteration");
            //foreach (var word in shortWords)
            //{
            //    Console.WriteLine(word);
            //}

            //words.Add("e");

            //Console.WriteLine("Second iteration");
            //foreach (var word in shortWords)
            //{
            //    Console.WriteLine(word);
            //}

            //var people = new List<Person>
            //{
            //    new Person("Jhon", "USA"),
            //    new Person("Betty", "UK")
            //};

            //var allAmericans = people.Where(person => person.Country == "USA");
            //var notAllAmericans = allAmericans.Take(100);

            //var animals = new List<string>()
            //{
            //    "Duck","Lion","Dolphin","Tiger"
            //};

            //var animalsWithD = animals.Where(animal =>
            //{
            //    Console.WriteLine("Checking animal:" + animal);
            //    return animal.StartsWith("D");
            //});

            //foreach(var animal in animalsWithD)
            //{
            //    Console.WriteLine(animal);
            //}
            #endregion

            #region Method vs Query Syntax
            //numbers = new[] { 4, 2, 7, 10, 12, 5, 4, 2 };

            //var smallOrderedNumbersMethodSyntax = numbers
            //    .Where(number => number < 10)
            //    .OrderBy(number => number)
            //    .Distinct();
            //Console.WriteLine(String.Join(", ", smallOrderedNumbersMethodSyntax));

            //var smallOrderedNumbersQuerySyntax = (from number in numbers
            //                                     where number < 10
            //                                     orderby number
            //                                     select number).Distinct();
            //Console.WriteLine(String.Join(", ", smallOrderedNumbersQuerySyntax));

            #endregion

            #region Any
            //numbers = new[] { 5, 9, 2, 12, 6 };
            //bool isAnyLargerThan10 = numbers.Any(number => number > 10);
            //Console.WriteLine(isAnyLargerThan10);

            //var isAnyPetNamedBruce = pets.Any(pet => pet.Name == "Bruce");
            //Printer.Print(isAnyPetNamedBruce, nameof(isAnyPetNamedBruce));

            //var isAnyFish = pets.Any(pet => pet.PetType == PetType.Fish);
            //Printer.Print(isAnyFish, nameof(isAnyFish));

            //var isAnyAVerySpecificPet = pets.Any(pet => 
            //    pet.Name.Length > 6 && pet.Id % 2 ==0);
            //Printer.Print(isAnyAVerySpecificPet, nameof(isAnyAVerySpecificPet));

            //var isNotEmpty = pets.Any(); //Checks if a collection has or not elements
            #endregion

            #region All
            //numbers = new[] { 5, 9, 2, 12, 6 };

            //var areAllNumbersLagerThanZero = numbers.All(number => number > 0);
            //Printer.Print(areAllNumbersLagerThanZero, nameof(areAllNumbersLagerThanZero));

            //var doAllHaveNonEmptyNames = pets.All(pet =>
            //    !string.IsNullOrEmpty(pet.Name));
            //Printer.Print(doAllHaveNonEmptyNames, nameof(doAllHaveNonEmptyNames));

            //var areAllCats = pets.All(pet => pet.PetType == PetType.Cat);
            //Printer.Print(areAllCats, nameof(areAllCats));
            #endregion

            #region Count and LongCount
            //var countOfDogs = pets.Count(pet => pet.PetType == PetType.Dog);
            //Printer.Print(countOfDogs, nameof(countOfDogs));

            //var countOfPetsNamedBruce = pets.LongCount(pet => pet.Name == "Bruce");
            //Printer.Print(countOfPetsNamedBruce, nameof(countOfPetsNamedBruce));

            //var countOfAllSmallDogs = pets.Count(pet => 
            //    pet.PetType == PetType.Dog && pet.Weight < 10 );
            //Printer.Print(countOfAllSmallDogs, nameof(countOfAllSmallDogs));

            //var allPetsCount = pets.Count();
            //Printer.Print(allPetsCount, nameof(allPetsCount));
            #endregion

            #region Contains
            //numbers = new[] { 16, 8, 9, -1, 2 };
            //bool is7Present = numbers.Contains(7);
            //Printer.Print(is7Present, nameof(is7Present));

            //words = new[] { "lion", "tiger", "snow leopard"};
            //bool isTigerPresent = words.Contains("tiger");
            //Printer.Print(isTigerPresent, nameof(isTigerPresent));

            //bool isHannibalPresentVersion1 = pets.Contains(
            //    new Pet(1, "Hannibal", PetType.Fish, 1.1f));
            //Printer.Print(isHannibalPresentVersion1, nameof(isHannibalPresentVersion1));

            //bool isHannibalPresentCustomComparer = pets.Contains(
            //    new Pet(1, "Hannibal", PetType.Fish, 1.1f), new PetCompareById());
            //Printer.Print(isHannibalPresentCustomComparer, nameof(isHannibalPresentCustomComparer));

            //var hannibal = pets.ToArray()[0];
            //bool isHannibalPresent = pets.Contains(hannibal);
            //Printer.Print(isHannibalPresent, nameof(isHannibalPresent));

            #endregion

            #region OrderBy

            //var petsOrderedByName = pets.OrderBy(pet => pet.Name);
            //Printer.Print(petsOrderedByName, nameof(petsOrderedByName));
            //Printer.Print(pets, nameof(pets));
            //var petsOrderedDesc = pets.OrderByDescending(pet => pet.Id);
            //Printer.Print(petsOrderedDesc, nameof(petsOrderedDesc));

            //numbers = new[] { 16, 8, 9, -1, 2 };
            //var orderedNumbers = numbers.OrderBy(x => x);
            //Printer.Print(orderedNumbers, nameof(orderedNumbers));

            //words = new[] { "lion", "tiger", "snow leopard" };
            //var orderedWordsDesc = words.OrderByDescending(x => x);
            //Printer.Print(orderedWordsDesc, nameof(orderedWordsDesc));

            //var petsOrderedByTypeThenName = pets
            //    .OrderBy(pet => pet.PetType)
            //    .ThenBy(pet => pet.Name);
            //Printer.Print(petsOrderedByTypeThenName, nameof(petsOrderedByTypeThenName));

            //var petsOrderedByTypeWithComparer = pets
            //   .OrderBy(pet => pet, new PetByTypeComparer());
            //Printer.Print(petsOrderedByTypeWithComparer, nameof(petsOrderedByTypeWithComparer));

            //var petsReversed = pets.Reverse();
            //Printer.Print(petsReversed, nameof(petsReversed));

            //var bools = new[] { true, false, true };
            //var orderedBools = bools.OrderBy(b => b);
            //Printer.Print(orderedBools, nameof(orderedBools));
            #endregion

            #region MinMax
            //numbers = new[] { 16, 8, 9, -1, 2 };
            //var smallest = numbers.Min();
            //var largest = numbers.Max();
            //Printer.Print(smallest, nameof(smallest));
            //Printer.Print(largest, nameof(largest));

            //var minWeight = pets.Min(p => p.Weight);
            //var maxWeight = pets.Max(p => p.Weight);
            //Printer.Print(minWeight, nameof(minWeight));
            //Printer.Print(maxWeight, nameof(maxWeight));


            //var minPet = pets.Min();
            //var maxPet = pets.Max();
            //Printer.Print(minPet, nameof(minPet));
            //Printer.Print(maxPet, nameof(maxPet));

            //var emptyNumbers = new int[0];
            //var minNumber = emptyNumbers.Min();
            #endregion

            #region Average
            //var averageNumbers = numbers.Average();
            //Printer.Print(averageNumbers, nameof(averageNumbers));

            //var averageWeightsOfPets = pets.Average(p => p.Weight);
            //Printer.Print(averageWeightsOfPets, nameof(averageWeightsOfPets));
            #endregion

            #region Sum
            //var sumNumbers = numbers.Sum();
            //Printer.Print(sumNumbers, nameof(sumNumbers));

            //var sumPetsWeight = pets.Sum(p => p.Weight);
            //Printer.Print(sumPetsWeight, nameof(sumPetsWeight));

            //var emptyCollection = new int[0];
            //var sum = emptyCollection.Sum();
            //Printer.Print(sum, nameof(sum));
            #endregion

            #region ElementAt
            // var firstNumber = numbers[0];
            // Printer.Print(firstNumber, nameof(firstNumber));

            // var secondPet = pets.ElementAt(1);
            // Printer.Print(secondPet, nameof(secondPet));

            ////var nonExistentPet = pets.ElementAt(10); // Throws an Exception
            // var nonExistentPetOrDefault = pets.ElementAtOrDefault(10);
            // Printer.Print(nonExistentPetOrDefault, nameof(nonExistentPetOrDefault));
            #endregion

            #region FirstAndLast
            //var firstNumber = numbers.First();
            //Printer.Print(firstNumber, nameof(firstNumber));

            //var firstOddNumber = numbers.First(n => n % 2 == 1);
            //Printer.Print(firstOddNumber, nameof(firstOddNumber));

            //var lastPetHeavierThan100 = pets.LastOrDefault(p => p.Weight > 100);
            //Printer.Print(lastPetHeavierThan100, nameof(lastPetHeavierThan100));

            //var lastDog = pets.Last(p => p.PetType == PetType.Dog);
            //Printer.Print(lastDog, nameof(lastDog));

            //var heaviestPet = pets.OrderBy(p => p.Weight).LastOrDefault();
            //Printer.Print(heaviestPet, nameof(heaviestPet));
            #endregion

            #region Single
            //numbers = new[] { 10, 1, 4, 17, 122 };
            //var singleLargerThan100 = numbers.Single(n => n > 100);
            //Printer.Print(singleLargerThan100, nameof(singleLargerThan100));

            ////var singleLargerThan15 = numbers.Single(n => n > 15);
            ////Printer.Print(singleLargerThan15, nameof(singleLargerThan15));

            //var singleElemArray = new int[] { 200 };
            //var singleElem = singleElemArray.Single();
            //Printer.Print(singleElem, nameof(singleElem));

            //var singleLargerThan150 = numbers.SingleOrDefault(x => x > 150);
            //Printer.Print(singleLargerThan150, nameof(singleLargerThan150));
            #endregion

            #region Where
            //numbers = new[] { 10, 1, 4, 17, 122 };
            //var evenNumbers = numbers.Where(n => n % 2 == 0);
            //Printer.Print(evenNumbers, nameof(evenNumbers));

            //var heavierThan10kilos = pets.Where(p => p.Weight > 10);
            //Printer.Print(heavierThan10kilos, nameof(heavierThan10kilos));

            //var heavierThan100kilos = pets.Where(p => p.Weight > 100);
            //Printer.Print(heavierThan100kilos, nameof(heavierThan100kilos));

            //var verySpecificPets = pets.Where(p => 
            //    (p.PetType == PetType.Cat || p.PetType == PetType.Dog) &&
            //    p.Name.Length >= 4 &&
            //    p.Weight > 10 &&
            //    p.Id % 2 == 0);
            //Printer.Print(verySpecificPets, nameof(verySpecificPets));

            //var indexesSelectedByUser = new[] { 1, 6, 7 };
            //var petsSelectedByUserAndLighterThan5kilos = pets
            //    .Where((pet, index) => 
            //        pet.Weight < 5 && 
            //        indexesSelectedByUser.Contains(index));
            //Printer.Print(petsSelectedByUserAndLighterThan5kilos, nameof(petsSelectedByUserAndLighterThan5kilos));

            //int countOfHeavyPets1 = pets.Count(p => p.Weight > 30);
            //int countOfHeavyPets2 = pets.Where(p => p.Weight > 30).Count();

            //Printer.Print(countOfHeavyPets1, nameof(countOfHeavyPets1));
            //Printer.Print(countOfHeavyPets2, nameof(countOfHeavyPets2));
            #endregion

            #region Take
            //numbers = new[] { 1, 4, 10, 154, 999, 15 };

            //var smallerThan20TakeWhile = numbers.TakeWhile(n => n < 20);
            //Printer.Print(smallerThan20TakeWhile, nameof(smallerThan20TakeWhile));

            //var first3Numbers = numbers.Take(30);
            //Printer.Print(first3Numbers, nameof(first3Numbers));

            //var last5Numbers = numbers.TakeLast(50);
            //Printer.Print(last5Numbers, nameof(last5Numbers));

            //var threeHeaviestPets = pets.OrderBy(p => p.Weight).TakeLast(3);
            //Printer.Print(threeHeaviestPets, nameof(threeHeaviestPets));

            //var secondLargestNumber = numbers.OrderBy(n => n).TakeLast(2).First();
            //Printer.Print(secondLargestNumber, nameof(secondLargestNumber));

            //var sixtyPercentOfPets = pets
            //    .Take((int)(pets.Count() * 0.6));
            //Printer.Print(sixtyPercentOfPets, nameof(sixtyPercentOfPets));

            //var allPetsBefore30KilosPet = pets.TakeWhile(p => p.Weight < 30);
            //Printer.Print(allPetsBefore30KilosPet, nameof(allPetsBefore30KilosPet));
            #endregion

            #region Skip
            //numbers = new[] { 1, 4, 10, 154, 999, 15 };

            //var skipWhileSmallerThan20 = numbers.SkipWhile(n => n < 20);
            //Printer.Print(skipWhileSmallerThan20, nameof(skipWhileSmallerThan20));
            //var skip3Numbers = numbers.Skip(3);
            //Printer.Print(skip3Numbers, nameof(skip3Numbers));

            //var skipLast2Numbers = numbers.SkipLast(2);
            //Printer.Print(skipLast2Numbers, nameof(skipLast2Numbers));

            //var skipLast2WithTake = numbers
            //    .Take(numbers.Count() - 2);
            //Printer.Print(skipLast2WithTake, nameof(skipLast2WithTake));

            //var secondHalfOfPets = pets.Skip(pets.Count()/2);
            //Printer.Print(secondHalfOfPets, nameof(secondHalfOfPets));

            //var secondPageOfPets = pets.Skip(2).Take(2);
            //Printer.Print(secondPageOfPets, nameof(secondPageOfPets));

            //var skipUntilHeavierThan30Kilos = pets.SkipWhile(p => p.Weight < 30);
            //Printer.Print(skipUntilHeavierThan30Kilos, nameof(skipUntilHeavierThan30Kilos));
            #endregion

            #region OfType
            //var objects = new object[]
            //{
            //    null,
            //    1,
            //    "all",
            //    2,
            //    "ducks",
            //    new List<int>(),
            //    "are",
            //    "awesome",
            //    true
            //};

            //var strings = objects.OfType<string>();
            //Printer.Print(strings, nameof(strings));

            //var flyables = new List<IFlyable>()
            //{
            //    new Bird(),
            //    new Plane(),
            //    new Helicopter()
            //};

            //var birds = flyables.OfType<Bird>();
            //Printer.Print(birds, nameof(birds));
            //var fuelables = flyables.OfType<IFuelable>();
            //Printer.Print(fuelables, nameof(fuelables));
            #endregion

            #region Distinct
            //numbers = new[] { 10, 1, 10, 4, 17, 17, 122 };
            //var numbersNoDuplicates = numbers.Distinct();
            //Printer.Print(numbersNoDuplicates, nameof(numbersNoDuplicates));

            //pets = new[]
            //{
            //    new Pet(1,"Hannibal", PetType.Fish, 1.1f),
            //    new Pet(1,"Hannibal", PetType.Fish, 1.1f)
            //};
            ////var petsNoDuplicates = pets.Distinct();
            ////Printer.Print(petsNoDuplicates, nameof(petsNoDuplicates));
            //var petsNoDuplicatesWithComparer = pets.Distinct(new PetEqualityById());
            //Printer.Print(petsNoDuplicatesWithComparer, nameof(petsNoDuplicatesWithComparer));
            #endregion

            #region Preppend/Append
            //var numbersWith100 = numbers.Append(100);
            //Printer.Print(numbers, nameof(numbers));
            //Printer.Print(numbersWith100, nameof(numbersWith100));

            //var petsWithBluebell = pets.Prepend(
            //    new Pet(0, "Bluebell", PetType.Dog, 25f));
            //Printer.Print(pets, nameof(pets));
            //Printer.Print(petsWithBluebell, nameof(petsWithBluebell));

            //var originalGrades = new[] { "Bad", "Medium", "Good" };
            //var newGrades = originalGrades.Prepend("Terrible").Append("Excellent");
            //Printer.Print(newGrades, nameof(newGrades));
            #endregion

            #region Concat/Union
            //var numbers1 = new[] { 1, 2, 3, 4, 5 };
            //var numbers2 = new[] { 4,5,6,7 };

            //var allNumbers = numbers1.Concat(numbers2);
            //Printer.Print(allNumbers, nameof(allNumbers));

            //var allNumbersNoDuplicates = numbers1.Union(numbers2);
            //Printer.Print(allNumbersNoDuplicates, nameof(allNumbersNoDuplicates));

            //var pets1 = new[]
            //{
            //    new Pet(1,"Hannibal", PetType.Fish, 1.1f),
            //    new Pet(2,"Anthony", PetType.Cat, 2f)
            //};
            //var pets2 = new[]
            //{
            //    new Pet(1,"Hannibal", PetType.Fish, 1.1f),
            //};

            //var unionOfPets = pets2.Union(pets1, new PetEqualityById());
            //Printer.Print(unionOfPets, nameof(unionOfPets));
            #endregion

            #region CollectionTypeChange
            //numbers = new[] { 1, 1, 2, 2, 2, 3 };
            //IEnumerable<long> longs = numbers.Cast<long>();

            //IEnumerable<PetType> allPetTypes = Enum.GetValues(typeof(PetType)).Cast<PetType>();
            //Printer.Print(allPetTypes, nameof(allPetTypes));

            //int[] numbersArray = numbers.ToArray();
            //List<int> arrayAsList = numbersArray.ToList();
            //HashSet<int> hashSetNumbers = numbers.ToHashSet();
            ////Printer.Print(hashSetNumbers, nameof(hashSetNumbers));

            //var idToNameDictionary = pets.ToDictionary(
            //    p => p.Id,
            //    p => p.Name);
            //Printer.Print(idToNameDictionary, nameof(idToNameDictionary));

            //var petTypeToNamesLookup = pets.ToLookup(
            //    p => p.PetType,
            //    p => p.Name);
            //Printer.Print(petTypeToNamesLookup, nameof(petTypeToNamesLookup));

            //var verySpecificList = new VerySpecificList<int> { 1, 2, 3, 4 };
            //var evenNumbers = verySpecificList
            //    .AsEnumerable()
            //    .Where(x => x % 2 == 0);
            //Printer.Print(evenNumbers, nameof(evenNumbers));
            #endregion

            #region Select
            //numbers = new[] { 10, 1, 4, 17, 122 };
            //var doubledNumbers = numbers.Select(n => n * 2);
            //Printer.Print(doubledNumbers, nameof(doubledNumbers));

            //var toUpperCase = words.Select(n => n.ToUpper());
            //Printer.Print(toUpperCase, nameof(toUpperCase));

            //IEnumerable<string> numbersAsStrings = numbers.Select(n => n.ToString());
            //Printer.Print(numbersAsStrings, nameof(numbersAsStrings));

            //var numberedWords = words.Select(
            //    (word, index) => $"{index + 1}. {word}");
            //Printer.Print(numberedWords, nameof(numberedWords));

            //var weights = pets.Select(p => p.Weight);
            //Printer.Print(weights, nameof(weights));

            //var heavierPetTypes = pets
            //    .Where(p => p.Weight > 4)
            //    .Select(p => p.PetType)
            //    .Distinct();
            //Printer.Print(heavierPetTypes, nameof(heavierPetTypes));

            //var petsInitials = pets
            //    .Select(p => p.Name[0] + ".")
            //    .OrderBy(n => n);
            //Printer.Print(petsInitials, nameof(petsInitials));

            //var petsData = pets.Select(p =>
            //    $"Pet named {p.Name}, of type {p.PetType} and weight {p.Weight}");
            //Printer.Print(petsData, nameof(petsData));
            #endregion

            #region SelectMany
            //var people = new[]
            //{
            //    new PetOwner(1, "Jhon", new[]
            //    {
            //        pets.ElementAt(0),
            //        pets.ElementAt(1)
            //    }),
            //    new PetOwner(1, "Jack", new[]
            //    {
            //        pets.ElementAt(2)
            //    }),
            //    new PetOwner(1, "Stephanie", new[]
            //    {
            //        pets.ElementAt(3),
            //        pets.ElementAt(4),
            //        pets.ElementAt(5)
            //    }),
            //};
            //var petsWithOwner = people
            //    .Where(p => p.Name.StartsWith('J'))
            //    .SelectMany(p => p.Pets)
            //    .Select(p => p.Name);
            //Printer.Print(petsWithOwner, nameof(petsWithOwner));

            //var nestedListOfNumbers = new List<List<int>>
            //{
            //    new List<int> {1,2,3},
            //    new List<int> {4,5,6},
            //    new List<int> {5,6}
            //};
            //var veryNestedListOfNumbers = new List<List<List<int>>>
            //{
            //    new List<List<int>>
            //    {
            //        new List<int> {1,2,3},
            //        new List<int> {4,5,6},
            //        new List<int> {5,6}
            //    },
            //    new List<List<int>>
            //    {
            //        new List<int> {10,12,13},
            //        new List<int> {14,15}
            //    }

            //};

            //var sum = nestedListOfNumbers.SelectMany(n => n).Sum();
            //Printer.Print(sum, nameof(sum));

            //var allNumbers = veryNestedListOfNumbers
            //    .SelectMany(innerList => innerList)
            //    .SelectMany(innerInnerList => innerInnerList);
            //Printer.Print(allNumbers, nameof(allNumbers));

            //var ownerPetPairsInfo = people
            //    .SelectMany(person => person.Pets,
            //    (person, pet) => $"{person.Name} is the owner of {pet.Name}");
            //Printer.Print(ownerPetPairsInfo, nameof(ownerPetPairsInfo));

            //numbers = new[] { 1, 2, 3 };
            //var letters = new[] { 'A', 'B', 'C' };

            //var carthesianProduct = new List<string>();
            //foreach(var number in numbers)
            //{
            //    foreach(var letter in letters)
            //    {
            //        carthesianProduct.Add($"{number},{letter}");
            //    }
            //}
            //var carthesianProduct = numbers.SelectMany(
            //    _ => letters, //We dont need param number because is not necessary
            //    (number, letter) => $"{number},{letter}");
            //Printer.Print(carthesianProduct, nameof(carthesianProduct));
            #endregion
            #region GeneratingNewCollections
            //var emptyInts = Enumerable.Empty<int>();
            //Printer.Print(emptyInts, nameof(emptyInts));

            //var tenCopiesOf100 = Enumerable.Repeat(100, 10);
            //Printer.Print(tenCopiesOf100, nameof(tenCopiesOf100));

            //var foxes = Enumerable.Repeat("fox", 3)
            //    .Select((word, index) => $"{index + 1}. {word}");
            //Printer.Print(foxes, nameof(foxes));

            //var from10to40 = Enumerable.Range(10, 21);
            //Printer.Print(from10to40, nameof(from10to40));

            //var powersOf2 = Enumerable.Range(0, 10)
            //    .Select(power => Math.Pow(2, power));
            //Printer.Print(powersOf2, nameof(powersOf2));

            //var letters = Enumerable.Range('A', 10)
            //    .Select(n => (char)n);
            //Printer.Print(letters, nameof(letters));

            //var nonEmptyNumbers = new[] { 1, 2, 3 };
            //var defaultIfEmpty1 = nonEmptyNumbers.DefaultIfEmpty();
            //Printer.Print(defaultIfEmpty1, nameof(defaultIfEmpty1));
            //var emptuNumbers = new int[0];
            //var defaultIfEmpty2 = emptuNumbers.DefaultIfEmpty(99);
            //Printer.Print(defaultIfEmpty2, nameof(defaultIfEmpty2));
            #endregion

        }


        public static bool IsAny<T>(
            IEnumerable<T> collection,
            Func<T, bool> predicate)
        {
            foreach (var intem in collection)
            {
                if (predicate(intem)) return true;
            }
            return false;
        }

        public static bool IsAnyWordUpperCase_LINQ(IEnumerable<string> words)
        {
            return words.Any(word =>
                word.All(letter => char.IsUpper(letter)));
        }

        public static bool IsAnyWordUpperCase(IEnumerable<string> words)
        {
            foreach (string word in words)
            {
                bool areAllUpperCase = true;
                foreach (var letter in word)
                {
                    if (char.IsLower(letter)) areAllUpperCase = false;
                }
                if (areAllUpperCase) return true;
            }
            return false;
        }

    }


    interface IFlyable
    {
        public void Fly();
    }
    interface IFuelable
    {
        public void Fuel();
    }

    class Bird : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flying by flapping my wings");
        }
    }
    class Plane : IFlyable, IFuelable
    {
        public void Fly()
        {
            Console.WriteLine("Flying by jet propulsion");
        }
        public void Fuel()
        {
            Console.WriteLine("Fuelling my large gas tank");
        }
    }
    class Helicopter : IFlyable, IFuelable
    {
        public void Fly()
        {
            Console.WriteLine("Flying by rotating my rotors");
        }
        public void Fuel()
        {
            Console.WriteLine("Fuelling my gas tank");
        }
    }

    class VerySpecificList<T> : List<T>
    {
        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            throw new InvalidOperationException(
                "I don't support filtering!");
        }
    }
}
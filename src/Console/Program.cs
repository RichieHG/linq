using Exercises;
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

            var numbers = new[] { 16, 8, 9, -1, 2 }; //new[] { 1, 4, 3, 99, 256, 2 };
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
            var sumNumbers = numbers.Sum();
            Printer.Print(sumNumbers, nameof(sumNumbers));

            var sumPetsWeight = pets.Sum(p => p.Weight);
            Printer.Print(sumPetsWeight, nameof(sumPetsWeight));

            var emptyCollection = new int[0];
            var sum = emptyCollection.Sum();
            Printer.Print(sum, nameof(sum));

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
}
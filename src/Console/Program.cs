﻿using Exercises;
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
            var numbers = new[] { 1, 4, 3, 99, 256, 2 };
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
            //var numbers = new List<int> { 5, 3, 7, 1, 2, 4 };
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
            numbers = new[] { 4, 2, 7, 10, 12, 5, 4, 2 };

            var smallOrderedNumbersMethodSyntax = numbers
                .Where(number => number < 10)
                .OrderBy(number => number)
                .Distinct();
            Console.WriteLine(String.Join(", ", smallOrderedNumbersMethodSyntax));

            var smallOrderedNumbersQuerySyntax = (from number in numbers
                                                 where number < 10
                                                 orderby number
                                                 select number).Distinct();
            Console.WriteLine(String.Join(", ", smallOrderedNumbersQuerySyntax));

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
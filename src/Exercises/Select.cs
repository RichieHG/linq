using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public static class Select
    {
        //Coding Exercise 1
        /*
         Imagine you work on an application that retrieves data from scanned paper 
        documents. Let's say you only want to retrieve numbers from some particular 
        documents, unfortunately, they contain other data, like dates, strings, etc.

        Implement the GetNumbers method, which given a collection of objects 
        of different types, will return a collection of integers. 
        Please note that if an object in the input collection is a string, 
        it should be parsed to int if possible.
        
        For example, for input collection 
            *{"1", 3, "abc", new DateTime(2020,1,2), true, "10"} the result shall be 
                {1,3,10}.
        
        The result collection shall be ordered from least to greatest.
         */
        public static IEnumerable<int> GetNumbers(IEnumerable<object> objects)
        {
            //TODO your code goes here
            var integers = objects.OfType<int>();
            var validStrings = objects
                .OfType<string>()
                .Select(s =>
                    {
                        int parseResult;
                        return int.TryParse(s, out parseResult) ? parseResult : (int?)null;
                    })
                .Where(v => v.HasValue)
                .Select(v => v.Value);
   
            return integers.Concat(validStrings).OrderBy(a => a);
        }

        //Coding Exercise 2
        /*
        Imagine you work on an application that retrieves data from scanned paper 
        documents. Those documents contain personal data which you want to convert to 
        C# objects.

        Implement the PeopleFromString method, which given a single string containing 
        personal data of multiple people, will return a collection of people. 
        If a person's data is not valid and can't be properly parsed, 
        this person should not be included in the result collection.
        
        For example, for an input string:        
            "John Smith, 1983/08/21;Jane Doe, 1993/12/21;Francis Brown, invalid date here"
        
        ...the result shall be a collection of two people: 
            John Smith and Jane Doe. 
        We shall not include Francis Brown, because his date of birth is not valid 
        and can't be parsed to a valid DateTime.
        
        As you can see in the example the separator between each person's data is ";", 
        and the full name and the date of birth are separated with ",".
         */
        public static IEnumerable<Person> PeopleFromString(string input)
        {
            //TODO your code goes here
            var people = input.Split(';');
            return people.Select(CreatePersonFromString)
            .Where(p => p is not null);
        }

        private static Person? CreatePersonFromString(string person)
        {
            var data = person.Split(',');
            var name = data[0].Split(' ');
            var dob = data[1].Trim();
            DateTime parseResult;
            return DateTime.TryParse(dob, out parseResult) ?
            new Person
            {
                FirstName = name[0].Trim(),
                LastName = name[1].Trim(),
                DateOfBirth = parseResult

            } :
            null;
        }
        //Refactoring challenge
        //TODO implement this method
        public static TimeSpan TotalDurationOfSongs_Refactored(string allSongsDuration)
        {
            //TODO your code goes here
            //return allSongsDuration.Any() ?
            //    TimeSpan.FromSeconds(
            //        allSongsDuration.Split(',').Sum( x =>
            //            TimeSpan.ParseExact( x, @"m\:ss", null).TotalSeconds)) : 
            //    new TimeSpan();
            return allSongsDuration.Any() ?
                TimeSpan.FromSeconds(
                    allSongsDuration.Split(',')
                    .Select(s => TimeSpan.ParseExact(s, @"m\:ss", null))
                    .Sum(x => x.TotalSeconds)) :
                new TimeSpan();
        }

        //do not modify this method
        public static TimeSpan TotalDurationOfSongs(
            string allSongsDuration)
        {
            if (string.IsNullOrEmpty(allSongsDuration))
            {
                return new TimeSpan();
            }

            var durationStrings = allSongsDuration.Split(',');
            var totalDuration = 0d;
            foreach (var durationString in durationStrings)
            {
                var timeSpan = TimeSpan.ParseExact(
                    durationString, @"m\:ss", null);
                totalDuration += timeSpan.TotalSeconds;
            }

            return TimeSpan.FromSeconds(totalDuration);
        }

        public class Person : IEquatable<Person>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }

            public override string ToString()
            {
                return $"{FirstName} {LastName} born on {DateOfBirth.ToString("d")}";
            }

            public bool Equals(Person other)
            {
                return FirstName == other.FirstName &&
                       LastName == other.LastName &&
                       DateOfBirth == other.DateOfBirth;
            }
        }
    }
}

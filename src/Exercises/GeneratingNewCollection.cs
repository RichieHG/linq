﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public static class GeneratingNewCollection
    {
        //Coding Exercise 1
        /*
         Implement the NewYearsEvesSince method, which given an initialYear and 
        yearsCount parameters, will build a dictionary with the key being the year, 
        and the value being the day of the week (as string) of the New Year's Eve. 
        Please assume the New Year's Eve is on the 31st of December 
        (according to the Gregorian calendar).

        For example, for initialYear 1900 and yearsCount 5, 
        the result shall be a dictionary with the following keys and values:        
            *[1900] = "Monday" ,        
            *[1901] = "Tuesday",         
            *[1902] = "Wednesday",        
            *[1903] = "Thursday",         
            *[1904] = "Saturday"
        
        As you can see this dictionary contains 5 elements because the yearsCount
        parameter was set to 5.
         */
        public static Dictionary<int, string> NewYearsEvesSince(
            int initialYear, int yearsCount)
        {
            //TODO your code goes here
            //return Enumerable.Range(initialYear, yearsCount)
            //    .Select(y => new
            //    {
            //        Year = y,
            //        Day = DateTime.Parse($"12/31/{y}").DayOfWeek.ToString()
            //    }).ToDictionary(y => y.Year, y => y.Day);
            return Enumerable
           .Range(initialYear, yearsCount)
           .ToDictionary(year => year,
           year => new DateTime(year, 12, 31).DayOfWeek.ToString());
        }

        //Coding Exercise 2
        /*
        Implement the BuildTree method, which given a number of levels, 
        will return a string representation of a tree. For example, for 5 levels 
        the result should be a string like this:
        "*
        **
        ***
        ****
        *****"

        Remember that to get the new line character, 
        you can use the Environment.NewLine property. 
        It will return "\n" when running on Unix systems, 
        and "\r\n" when running on Windows (the new line symbol
        is different for those two systems). 
        This way, no matter where your code is run, it will work correctly.

         */
        public static string BuildTree(int levels)
        {
            //TODO your code goes here
            return string.Join('\n',
                    Enumerable.Range(1, levels)
                    .Select(i => string.Join("",Enumerable.Repeat('*',i)))
                ).Trim();
        }

        //Refactoring challenge
        //TODO implement this method
        public static IEnumerable<string> DoubleLetters_Refactored(int countOfLetters)
        {
            //TODO your code goes here
            var letters = Enumerable.Range('A', Math.Min(countOfLetters, 26));
            return letters.SelectMany(_ => letters,
            (letter1, letter2) => $"{(char)letter1}{(char)letter2}");
        }

        //do not modify this method
        public static IEnumerable<string> DoubleLetters(int countOfLetters)
        {
            const int CountOfLettersInEnglishAlphabet = 26;
            var finalCountOfLetters = Math.Min(
                countOfLetters,
                CountOfLettersInEnglishAlphabet);

            var allLetters = new List<char>();
            var letter = 'A';
            for (int i = 0; i < finalCountOfLetters; ++i)
            {
                allLetters.Add(letter);
                letter++;
            }

            var result = new List<string>();
            foreach (var firstLetter in allLetters)
            {
                foreach (var secondLetter in allLetters)
                {
                    result.Add($"{firstLetter}{secondLetter}");
                }
            }
            return result;
        }
    }
}

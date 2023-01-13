using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public static class Aggregate
    {
        //Coding Exercise 1
        /*
        Imagine you are working on an activity tracker app. On the main screen, 
        we want to show the user the total activity time for the current day.

        Using the Aggregate method, implement the TotalActivityDuration method, 
        which given a collection of integers representing activities durations 
        in seconds will return a TimeSpan object representing the total time of activity.

        For example, for durations {10, 50, 121} the result shall be a TimeSpan 
        object with a total duration of 3 minutes and 1 second.
         */
        public static TimeSpan TotalActivityDuration(
            IEnumerable<int> activityTimesInSeconds)
        {
            //TODO your code goes here
            //return activityTimesInSeconds.Aggregate(
            //    new TimeSpan(),
            //    (totalTimeSoFar, activityTime) =>
            //    totalTimeSoFar.Add(TimeSpan.FromSeconds(activityTime)));

            return TimeSpan.FromSeconds(activityTimesInSeconds.Aggregate((totalTimeSoFar, activityTime) =>
               totalTimeSoFar + activityTime));
        }

        //Coding Exercise 2
        /*
         Using LINQ's Aggregate method implement the PrintAlphabet method which given 
        a count (assume it's from 1 to 26) will return a string with this count 
        of letters starting with 'a'.

        For example:
            *For count 5 it will return "a,b,c,d,e"
            *For count 3 it will return "a,b,c"
            *For count 1 it will return "a"
        
        For count less than 1 or more than 26 it will throw ArgumentException
         */
        public static string PrintAlphabet(int count)
        {
            //TODO your code goes here
            return count > 0 && count < 26 ? Enumerable.Range('b', count-1).Aggregate(
                "a",
                (stringSoFar, nextLetter) => $"{stringSoFar},{(char)nextLetter}") :
                throw new ArgumentException($"'{nameof(count)}' must be between 1 and 26");
        }

        //Refactoring challenge
        //TODO implement this method
        public static IEnumerable<int> Fibonacci_Refactored(int n)
        {
            //TODO your code goes here
            /*
             We need to do this operation N-2 times (which is reflected in the 
            Range method) because the seed initially has the first two elements 
            of the sequence. For example, for n=3 we want to extend the seed 
            sequence {0,1} only once, to create the result sequence of {0,1,1}.
            */
            return n < 1 ? throw new ArgumentException(
                    $"Can't generate Fibonacci sequence " +
                    $"for {n} elements. N must be a " +
                    $"positive number") :
                    n == 1 ? new[] { 0 } :
                    Enumerable.Range(1,n - 2).Aggregate(
                        new List<int> { 0,1 } as IEnumerable<int>,
                        (fiboSoFar, nextNumber) => 
                        fiboSoFar.Append(fiboSoFar.ElementAt(nextNumber - 1) + fiboSoFar.ElementAt(nextNumber)));
        }

        //do not modify this method
        public static IEnumerable<int> Fibonacci(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException(
                    $"Can't generate Fibonacci sequence " +
                    $"for {n} elements. N must be a " +
                    $"positive number");
            }

            if (n == 1)
            {
                return new[] { 0 };
            }
            var result = new List<int> { 0, 1 };
            for (int i = 1; i < n - 1; ++i)
            {
                result.Add(result[i - 1] + result[i]);
            }
            return result;
        }
    }
}

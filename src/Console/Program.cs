using Exercises;
namespace ConsoleSample
{
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

            var wordsNoUpperCase = new string[] {
                "quick", "brown", "fox"
            };
            //Console.WriteLine(IsAnyWordUpperCase(wordsNoUpperCase));    
            Console.WriteLine(IsAnyWordUpperCase_LINQ(wordsNoUpperCase));    
            var wordsWithUpperCase = new string[] {
                "quick", "brown", "FOX"
            };
            //Console.WriteLine(IsAnyWordUpperCase(wordsWithUpperCase));
            Console.WriteLine(IsAnyWordUpperCase_LINQ(wordsWithUpperCase));

            var orderedWords = wordsNoUpperCase.OrderBy(word => word);



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
                foreach(var letter in word)
                {
                    if(char.IsLower(letter)) areAllUpperCase = false;
                }
                if(areAllUpperCase) return true;
            }
            return false;
        }
    }
}
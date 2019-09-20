using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ to Objects *****\n");
            QueryOverStrings();
            QueryOverStringsWithExtensionMethods();
            QueryOverStringsLongHand();
            QueryOverInts();
            Console.ReadLine();
        }

        static void QueryOverStrings()
        {
            Console.WriteLine("***** Query over strings *****");

            // Assume we have an array of strings.
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Build a query expression to find the items in the array that have an embedded space.
            IEnumerable<string> subset = from g in currentVideoGames where g.Contains(" ") orderby g select g;

            ReflectOverQueryResults(subset);

            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
            Console.WriteLine();
        }

        static void QueryOverStringsWithExtensionMethods()
        {
            Console.WriteLine("***** Query over strings with extension methods *****");
            // Assume we have an array of strings.
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Build a query expression to find the items in the array that have an embedded space.
            IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);
            ReflectOverQueryResults(subset, "Extension Methods");
            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);

            Console.WriteLine();
        }

        static void QueryOverStringsLongHand()
        {
            Console.WriteLine("***** Query over strings, longhand *****");

            // Assume we have an array of strings.
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            string[] gameWithSpaces = new string[5];

            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                    gameWithSpaces[i] = currentVideoGames[i];
            }

            // Now sort the items.
            Array.Sort(gameWithSpaces);

            // Print out the results
            foreach (string s in gameWithSpaces)
            {
                if (s != null)
                    Console.WriteLine("Item: {0}", s);
            }
            ReflectOverQueryResults(gameWithSpaces);

            Console.WriteLine();
        }

        static void QueryOverInts()
        {
            Console.WriteLine("***** Query over ints *****");
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            // Print only items less than 10.
            var subset = from i in numbers where i < 10 select i;

            foreach (var i in subset)
                Console.WriteLine("Item: {0}", i);
            ReflectOverQueryResults(subset);

            Console.WriteLine();
        }

        static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
        {
            Console.WriteLine($"***** Info about your query using {queryType} *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }
    }
}

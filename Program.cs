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
            Console.ReadLine();
        }

        static void QueryOverStrings()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Build a query expression to find the items in the array that have an embedded space.
            IEnumerable<string> subset = from g in currentVideoGames where g.Contains(" ") orderby g select g;

            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }
    }
}

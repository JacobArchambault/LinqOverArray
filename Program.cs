﻿using System;
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

        static void QueryOverStringsWithExtensionMethods()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Build a query expression to find the items in the array that have an embedded space.
            IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);

            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);

        }

        static void QueryOverStringsLongHand()
        {
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

        }
    }
}

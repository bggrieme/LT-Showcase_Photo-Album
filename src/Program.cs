using System;
using System.Collections.Generic;

namespace LTShowcase
{
    class Program
    {
        static void Main(string[] args)
        {
            string SourceAddress = "https://jsonplaceholder.typicode.com/photos";
            JsonQueryManager QueryManager = new JsonQueryManager(SourceAddress);
            bool willContinue = true;
            while (willContinue)
            {
                Console.Clear();
                Console.WriteLine("Please enter which albums you would like to view. e.g. \"1-5, 8, 7-10\"");
                string input = Console.ReadLine();
                Console.WriteLine(QueryManager.GetQueriedAlbumsString(input));
                Console.WriteLine("Would you like to view another set of albums? y / n");
                string continueResponse = Console.ReadLine();
                if (continueResponse == "n")
                {
                    willContinue = false;
                }
            }
        }
    }
}
using System;//Console
using System.Collections.Generic;

namespace LTShowcase
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "https://jsonplaceholder.typicode.com/photos";
            InputManager inputManager = new InputManager();
            PhotoProcessor photoProcessor = new PhotoProcessor(address);

            bool willContinue = true;
            while (willContinue)
            {
                Console.WriteLine("Please enter which albums you would like to view. e.g. \"1-5, 8, 7-10\"");
                List<int> albumIDs = inputManager.ParseInputToList(Console.ReadLine());
                Console.WriteLine(photoProcessor.PhotoID_andTitle_GroupedBy_Album(albumIDs));
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
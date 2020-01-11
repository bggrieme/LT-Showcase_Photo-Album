using System;//Console

namespace LT_Showcase
{
    class Program
    {
        static void Main(string[] args)
        {
            PhotoProcessor proc = new PhotoProcessor("https://jsonplaceholder.typicode.com/photos");
            proc.print_id_and_title_GroupedBy_albumId();
            Console.ReadKey(); //this is only here to prevent the console from automatically closing.. I seem to recall this not being necessary in visual studio, so maybe it's only a Visual Studio Code thing.
        }
    }
}
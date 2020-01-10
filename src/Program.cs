using System;
using System.Net; //WebClient class
using System.Linq;
using Newtonsoft.Json.Linq;

namespace LT_Showcase
{
    class Program
    {
        static void Main(string[] args)
        {

            //initial research process..
            WebClient wc = new WebClient();
            string json = wc.DownloadString("https://jsonplaceholder.typicode.com/photos");
            JArray rss = JArray.Parse(json);

            var photos =
                from data in rss
                select new
                {
                    albumId = (string)data["albumId"],
                    id = (string)data["id"],
                    title = (string)data["title"],
                    url = (string)data["url"],
                    thumbnailUrl = (string)data["thumbnailUrl"]
                };

            var queryPhotos =
                from all in photos
                where all.albumId == "3"
                select all;



            Console.WriteLine(rss[0].ToString());



            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
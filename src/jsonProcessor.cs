using System;
using System.Linq; 
using Newtonsoft.Json.Linq;

namespace LT_Showcase
{
    public class jsonProcessor
    {
        JArray token_array {get; private set;}
        public jsonProcessor(string jsonAddress)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            this.token_array = JArray.Parse(wc.DownloadString(jsonAddress)); //WebClient downloads the given address as a string, and JArray.Parse breaks that string into individual json tokens which are then stored in token_array
        }

        //TODO: write stubs. consider dynamic return type for query methods. Write some tests.
    }
}
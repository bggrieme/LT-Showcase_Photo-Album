using System;
using System.Linq; 
using Newtonsoft.Json.Linq;

namespace LT_Showcase
{
    public class jsonProcessor
    {
        JArray token_array {get; private set;}
        public jsonProcessor(string jsonWebAddress)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            this.token_array = JArray.Parse(wc.DownloadString(jsonWebAddress)); //WebClient downloads the given address as a string, and JArray.Parse breaks that string into individual json tokens which are then stored in token_array
        }
        

        //TODO: write stubs. Write some tests. Implement stubs. Run tests, etc.
        
        //basic query function
        public string id_and_title_by_album(){
            //TODO: design thoughts - probably best to pass a specific album id as an argument and build the return based off of that
            //as opposed to processing the entire json at once. A little more future-proof this way.
        }
    }
}
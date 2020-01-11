using System;
using System.Linq; 
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace LT_Showcase
{
    public class PhotoProcessor
    {
        public List<Photo> photos_List {get; private set;}

        public PhotoProcessor(string jsonWebAddress)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            JArray JArr = JArray.Parse(wc.DownloadString(jsonWebAddress)); //WebClient downloads the given address as a string, and JArray.Parse breaks that string into individual json tokens which are then stored in token_array
            IList<JToken> jsonTokens = JArr.Children().ToList();      
            foreach(JToken t in JArr)
            {
                this.photos_List.Add(t.ToObject<Photo>());
            }
        }
        //TODO: write stubs. Write some tests. Implement stubs. Run tests, etc.
        
        //Returns a subset of the data filtered by a given albumId
        public List<Photo> subset_by_album(int albumId){
            List<Photo> photos_List = new List<Photo>();

            return photos_List;
        }
    }
}
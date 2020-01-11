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
            this.photos_List = new List<Photo>();
            System.Net.WebClient wc = new System.Net.WebClient();
            JArray JArr = JArray.Parse(wc.DownloadString(jsonWebAddress)); //WebClient downloads the given address as a string, and JArray.Parse breaks that string into individual json tokens which are then stored in token_array
            IList<JToken> jsonTokens = JArr.Children().ToList();      
            foreach(JToken t in JArr)
            {
                this.photos_List.Add(t.ToObject<Photo>());
            }
        }

        //Returns a subset of the data filtered by a given albumId
        public List<Photo> subset_by_album(string albumId){
            List<Photo> queryResults = new List<Photo>();
            var results = 
                from all in photos_List
                where all.albumId == albumId
                select all;
            foreach(Photo p in results)
            {
                queryResults.Add(p);
            }
            return queryResults;
        }
    }
}
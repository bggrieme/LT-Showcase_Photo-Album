using System; //Console
using System.Linq; //query clauses and lots of other useful data manipulation things
using Newtonsoft.Json.Linq; //JArray, JToken, other JThings
using System.Collections.Generic; //List, IGrouping

namespace LTShowcase
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
                this.photos_List.Add(t.ToObject<Photo>()); //deserialize each JToken into a Photo obj and add it to the List
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

        /*Prints all photos to console in the following example format
        > photo-album 1
        [photo ID] photo title
        [photo ID] photo 
        
        > photo-album 2
        [photo ID] photo title
        [photo ID] photo title
        etc. etc. */
        public void print_id_and_title_GroupedBy_albumId()
        {
            var group =
                from photo in this.photos_List
                group photo by photo.albumId; //an IEnumerable<IGrouping<, Photo>>
            foreach (var grouping in group) //for each IGrouping in IEnumerable<IGrouping<, Photo>>
            {
                Console.WriteLine("> photo-album " + grouping.Key);
                foreach (var photo in grouping) //for each photo in each IGrouping..
                {
                    Console.WriteLine("[{0}] {1}", photo.id, photo.title);
                }
                Console.WriteLine(); //just a blank line between albums for presentation purposes
            }
        }
    }
}
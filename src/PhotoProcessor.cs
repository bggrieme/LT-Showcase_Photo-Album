using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace LTShowcase
{
    public class PhotoProcessor
    {
        public const string WebAddress = "https://jsonplaceholder.typicode.com/photos";
        private WebClient Web = new WebClient();

        public PhotoProcessor() { }

        /*Prints all photos to console in the following example format
        > photo-album 1
        [photo ID] photo title
        [photo ID] photo 
        
        > photo-album 2
        [photo ID] photo title
        [photo ID] photo title
        etc. etc. */
        public void PrintAlbum(int albumId)
        {
            List<Photo> queryResults = this.GetAlbumPhotos(albumId);
            if (queryResults.Count == 0)
            {
                Console.WriteLine("*** Album " + albumId + " is empty or nonexistent. ***");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("> photo-album " + albumId);
            foreach (Photo photo in queryResults)
            {
                Console.WriteLine("[{0}] {1}", photo.id, photo.title);
            }
            Console.WriteLine();
        }

        //Grabs the indicated album data directly from the source. Deserializes this data into Photo objects and returns a List of these objects.
        public List<Photo> GetAlbumPhotos(int albumId)
        {
            string albumWebAddress = WebAddress + "?albumId=" + albumId;
            JArray jArr = JArray.Parse(Web.DownloadString(albumWebAddress));
            List<JToken> jsonTokens = jArr.Children().ToList();
            List<Photo> photos = new List<Photo>();
            foreach (JToken token in jArr)
            {
                photos.Add(token.ToObject<Photo>());
            }
            return photos;
        }
    }
}
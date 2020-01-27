using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace LTShowcase
{
    public class PhotoProcessor
    {
        private WebClient Web = new WebClient();
        public readonly string WebAddress = "";

        public PhotoProcessor(string webAddress)
        {
            this.WebAddress = webAddress;
        }

        /*Returns a string in the following example format
        > photo-album 1
        [photo ID 1] photo 1 title
        [photo ID 2] photo 2 title
        etc. etc. */
        public string PhotoID_andTitle_GroupedBy_Album(List<int> albumIDs)
        {
            string result = "";
            List<Photo> queryResults = this.GetAlbumPhotos(albumIDs);
            IEnumerable<IGrouping<string, Photo>> albums = 
                from photo in queryResults
                group photo by photo.albumId;

            foreach (IGrouping<string, Photo> group in albums)
            {
                result += "> photo-album " + group.Key + "\n";
                foreach(Photo photo in group)
                {
                    result += "[" + photo.id + "] " + photo.title + "\n";
                }
                result += "\n";
            }
            return result;
        }

        //Grabs the indicated album data directly from the source. Deserializes this data into Photo objects and returns a List of these objects.
        public List<Photo> GetAlbumPhotos(List<int> albumIDs)
        {
            string albumWebAddress = this.WebAddress;
            BuildQueriedWebAddress(ref albumWebAddress, albumIDs);
            JArray jArr = JArray.Parse(Web.DownloadString(albumWebAddress));
            List<JToken> jsonTokens = jArr.Children().ToList();
            List<Photo> photos = new List<Photo>();
            foreach (JToken token in jArr)
            {
                photos.Add(token.ToObject<Photo>());
            }
            return photos;
        }

        //This helper method builds a URL containing a single query to get all of the albums in one call of WebClient.DownloadString. I introduced this after observing how long a single call can take and decided to minimize the number of these calls needed.
        private void BuildQueriedWebAddress(ref string address, List<int> albumIDs)
        {
            address += "?";
            foreach(int albumID in albumIDs)
            {
                address += "albumId=" + albumID + "&";
            }
        }
    }
}
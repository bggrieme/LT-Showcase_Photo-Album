using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace LTShowcase
{
    public class PhotoProcessor
    {
        private WebClient Web = new WebClient();
        public readonly string WebAddress;
        public List<Photo> Photos = new List<Photo>();
        
        public PhotoProcessor(string webAddress)
        {
            this.WebAddress = webAddress;
        }

        /*Returns a string built from the current contents of this.Photos in the following example format
        > photo-album 1
        [photo ID 1] photo 1 title
        [photo ID 2] photo 2 title
        etc. etc. */
        public string PhotoIDsAndTitlesGroupedByAlbum()
        {
            string result = "";
            IEnumerable<IGrouping<string, Photo>> albums = 
                from photo in this.Photos
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

        //Grabs the indicated album data directly from the source URL. Deserializes this data into Photo objects and places them into the list of Photos.
        public void DownloadPhotos(List<int> albumIDs)
        {
            this.Photos.Clear();
            string albumWebAddress = this.WebAddress;
            BuildQueriedWebAddress(ref albumWebAddress, albumIDs);
            JArray jArr = JArray.Parse(Web.DownloadString(albumWebAddress));
            foreach (JToken token in jArr)
            {
                this.Photos.Add(token.ToObject<Photo>());
            }
        }

        //This helper method builds a URL containing a single query to get all of the desired albums in one call of WebClient.DownloadString.
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
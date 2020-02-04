using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace LTShowcase
{
    public class PhotoProcessor
    {
        public List<Photo> Photos = new List<Photo>();
        
        public PhotoProcessor(JArray jsonPhotos)
        {
            foreach (JToken token in jsonPhotos)
            {
                Photos.Add(token.ToObject<Photo>());
            }
        }
        public PhotoProcessor(List<Photo> photos)
        {
            Photos = photos;
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
                from photo in Photos
                group photo by photo.AlbumId;
            foreach (IGrouping<string, Photo> group in albums)
            {
                result += "> photo-album " + group.Key + "\n";
                foreach(Photo photo in group)
                {
                    result += "[" + photo.Id + "] " + photo.Title + "\n";
                }
                result += "\n";
            }
            return result;
        }


    }
}
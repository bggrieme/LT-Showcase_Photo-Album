using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Net;

namespace LTShowcase
{
    public class JsonQueryManager
    {
        private InputManager InputMgr;
        private PhotoProcessor PhotoProc;
        private string JsonSourceAddress;

        public JsonQueryManager(string sourceAddress)
        {
            JsonSourceAddress = sourceAddress;
            InputMgr = new InputManager();
        }

        public string GetQueriedAlbumsString(string input)
        {
            List<int> selectedAlbums = InputMgr.ParseInputToList(input);
            string queriedURL = BuildQueriedURL(JsonSourceAddress, selectedAlbums);
            PhotoProc = new PhotoProcessor(this.GetJArray(queriedURL));
            return PhotoProc.PhotoIDsAndTitlesGroupedByAlbum();
        }

        //Builds a URL containing a single query to get all of the desired albums in one call of WebClient.DownloadString.
        private string BuildQueriedURL(string baseURL, List<int> albumIDs)
        {
            string queriedURL = baseURL;
            queriedURL += "?";
            foreach (int albumID in albumIDs)
            {
                queriedURL += "albumId=" + albumID + "&";
            }
            return queriedURL;
        }

        private JArray GetJArray(string sourceAddress)
        {
            WebClient webClient = new WebClient();
            return JArray.Parse(webClient.DownloadString(sourceAddress));
        }
    }
}
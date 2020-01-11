public class Photo
{
    public string albumId;
    public string id;
    public string title;
    public string url;
    public string thumbnailUrl;
    
    public Photo(string albumId, string id, string title, string url, string thumbnailUrl)
    {
        this.albumId = albumId;
        this.id = id;
        this.title = title;
        this.url = url;
        this.thumbnailUrl = thumbnailUrl;
    }

}
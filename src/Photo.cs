public class Photo
{
    public string AlbumId;
    public string Id;
    public string Title;
    public string Url;
    public string ThumbnailUrl;
    
    public Photo(string albumId, string id, string title, string url, string thumbnailUrl)
    {
        AlbumId = albumId;
        Id = id;
        Title = title;
        Url = url;
        ThumbnailUrl = thumbnailUrl;
    }

}
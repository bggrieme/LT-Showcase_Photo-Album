using System.Reflection;
using Xunit;
using System.Linq;
using LTShowcase;
using System.Collections.Generic;

public class PhotoProcessor_tests
{
    List<Photo> testPhotos = new List<Photo>();

    [Fact]
    public void PhotoIDsAndTitlesGroupedByAlbum_Returns_FormattedString()
    {
        this.GenerateAndAddTestAlbum(ref this.testPhotos, "1", 1);
        this.GenerateAndAddTestAlbum(ref this.testPhotos, "2", 1);
        PhotoProcessor photoProc = new PhotoProcessor(this.testPhotos);
        string expected = "> photo-album 1\n[1] title1-1\n\n" + "> photo-album 2\n[1] title2-1\n\n";
        Assert.True(photoProc.PhotoIDsAndTitlesGroupedByAlbum() == expected);
    }
    
    //helper method used to generate several Photo objects with procedurally generated member values
    private void GenerateAndAddTestAlbum(ref List<Photo> photos, string albumId, int numPhotos)
    {
        Photo[] album = new Photo[numPhotos];

        for (int i = 1; i <= numPhotos; i++)
        {
            string id, title, url, thumbnailUrl;
            id = i.ToString();
            title = "title" + albumId + "-" + i;
            url = "url" + albumId + "-" + i;
            thumbnailUrl = "thumbUrl" + albumId + "-" + i;
            album[i-1] = new Photo(albumId, id, title, url, thumbnailUrl);
        }
        foreach(Photo photo in album)
        {
            photos.Add(photo);
        }
    }
}
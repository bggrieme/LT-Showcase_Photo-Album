using Xunit;
using System.Linq;
using LTShowcase;
using System.Collections.Generic;

/*Note: these tests are really only good as long as the source json doesn't change, which it shouldn't. 
If it weren't a static source, I would recommend creating a source file that the developers control to be used for testing purposes.*/
public class PhotoProcessor_tests
{    
    PhotoProcessor photos = new PhotoProcessor("https://jsonplaceholder.typicode.com/photos");
    const int PHOTO_COUNT = 5000; //total number of photo items
    const int ALBUM_ID_3_COUNT = 50; //total number of photo items in "albumID" 3

    /*Checks the Count of the full set.*/
    [Fact (DisplayName = ("Check Photo count integrity. Should get 5000"))]
    public void FullSet_JArray_Count()
    {
        Assert.True(photos.photos_List.Count() == PHOTO_COUNT, "Expected count: " + PHOTO_COUNT + " | Actual count: " + photos.photos_List.Count());
    }

    /*Queries the full set to produce a subset and checks the count of this subset.*/
    [Theory (DisplayName = "Query of album 3 from the set should contain 50 items.")]
    [InlineData ("3", ALBUM_ID_3_COUNT)]
    public void SubSet_Album3_Count(string albumId, int expectedCount)
    {
        IList<Photo> subset = photos.subset_by_album(albumId);
        Assert.True(subset.Count() == expectedCount, "Expected count: " + expectedCount + " | Actual count: " + subset.Count());
    }

    /*Creates data subset from given albumId. Checks albumId of each member of that subset against the intended albumId*/
    [Theory (DisplayName = "After creating a subset by albumId, each item in the subset should have the same expected albumId")]
    [InlineData ("1")]
    public void Subset_by_AlbumId(string albumId)
    {
        IList<Photo> subset = photos.subset_by_album(albumId);
        bool allAlbumIdCorrect = true;
        foreach(Photo p in subset)
        {
            if(p.albumId != albumId)
            {
                allAlbumIdCorrect = false;
            }
        }
        Assert.True(allAlbumIdCorrect, "Subset contained member(s) from an album other than the one expected.");
    }

    /*Checks the 5 member values of the first and last Photo items using values taken directly from the json file*/
    [Fact (DisplayName = "Deserialization confirmation: Checks values of first and last Photo objects against known expectations.")]
    public void Deserialization_confirmation()
    {
        Photo p1 = photos.photos_List[0];        
        Assert.True(p1.albumId == "1", "Deserialization error. Got unexpected album id.");
        Assert.True(p1.id == "1", "Deserialization error. Got unexpected photo id.");
        Assert.True(p1.title == "accusamus beatae ad facilis cum similique qui sunt", "Deserialization error. Got unexpected title.");
        Assert.True(p1.url == "https://via.placeholder.com/600/92c952", "Deserialization error. Got unexpected URL.");
        Assert.True(p1.thumbnailUrl == "https://via.placeholder.com/150/92c952", "Deserialization error. Got unexpected thumbnail URL.");
        Photo p5000 = photos.photos_List[4999];
        Assert.True(p5000.albumId == "100", "Deserialization error. Got unexpected album id.");
        Assert.True(p5000.id == "5000", "Deserialization error. Got unexpected photo id.");
        Assert.True(p5000.title == "error quasi sunt cupiditate voluptate ea odit beatae", "Deserialization error. Got unexpected title.");
        Assert.True(p5000.url == "https://via.placeholder.com/600/6dd9cb", "Deserialization error. Got unexpected URL.");
        Assert.True(p5000.thumbnailUrl == "https://via.placeholder.com/150/6dd9cb", "Deserialization error. Got unexpected thumbnail URL.");
    }
}
using Xunit;
using System.Linq;
using LT_Showcase;

public class json_tests
{
    /*Note: these tests are really only good as long as the source json doesn't change, which it shouldn't. 
    If it weren't a static source, I would recommend creating a source file that the developers control to be used for testing purposes.*/
    PhotoProcessor photos = new PhotoProcessor("https://jsonplaceholder.typicode.com/photos");
    const int PHOTO_COUNT = 5000; //total number of photo items
    const int ALBUM_ID_3_COUNT = 50; //total number of photo items in "albumID" 3

    /*Checks the Count of the full set.*/
    [Fact (DisplayName = ("Check Photo count integrity. Should get 5000"))]
    public void FullSet_JArray_Count()
    {
        Assert.True(photos.photos_List.Count() == PHOTO_COUNT);
    }

    /*Queries a subset of the full set and checks the count of this subset.*/
    [Theory (DisplayName = "Query of album 3 from the set should contain 50 items.")]
    [InlineData (3, ALBUM_ID_3_COUNT)]
    public void SubSet_Album3_Count(int albumId, int expectedCount)
    {
        Assert.True(photos.subset_by_album(albumId).Count() == expectedCount);
    }


}
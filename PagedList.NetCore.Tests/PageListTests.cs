using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace PagedList.NetCore.Tests
{
    public class PageListTests
    {
        private string url = "http://www.myapp.com/my-path?pageNumber=5&sortField=someField&sortMode=DESC";

        private string urlAfterMountingWithoutPageNumber = "http://www.myapp.com/my-path?sortField=someField&sortMode=DESC&pageSize=10&pageNumber=";

        private JsonSerializerSettings jsonSerializer = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        [Fact]
        public void PagedList_Construct_GenerateProps()
        {
            // arrange
            int itemCount = 347;
            int pageSize = 12;
            int pageNumber = 1;

            // act
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize);

            // assert
            Assert.NotNull(pagedList.Options);
            Assert.NotNull(pagedList.Navigator);
        }
        
        [Fact]
        public void PagedList_Construct_Default()
        {
            // arrange
            int itemCount = 347;

            // act
            PagedList pagedList = new PagedList(url, itemCount);

            // assert
            Assert.NotNull(pagedList.Options);
            Assert.NotNull(pagedList.Navigator);
            Assert.Null(pagedList.Navigator.NavigatorSize);
            Assert.Null(pagedList.Navigator.Numerics);
            Assert.Equal(pagedList.Options.PageNumber, 1);
            Assert.Equal(pagedList.Options.PageSize, 10);
        }

        [Fact]
        public void PagedList_Construct_PageOptions()
        {
            // arrange
            int itemCount = 347;
            int pageSize = 10;
            int pageNumber = 7;
            int navigatorSize = 6;

            // act
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            Assert.NotNull(pagedList.Options);
            Assert.Equal(pagedList.Options.PageCount, 35);
            Assert.Equal(pagedList.Options.PageNumber, pageNumber);
            Assert.Equal(pagedList.Options.PageSize, pageSize);
        }

        [Fact]
        public void PagedList_Construct_UrlNavigator()
        {
            // arrange
            int itemCount = 347;
            int pageSize = 10;
            int pageNumber = 7;
            int navigatorSize = 6;

            // act
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            Assert.NotNull(pagedList.Navigator);
            Assert.Equal(pagedList.Navigator.NavigatorSize, 6);
            Assert.Equal(pagedList.Navigator.Numerics.Count, 6);
            Assert.Equal(pagedList.Navigator.Numerics[2].Number, pageNumber);
        }

        [Fact]
        public void PagedList_Construct_PageOptionsAndUrlNavigator_FirstPage()
        {
            // arrange
            int itemCount = 347;
            int pageSize = 10;
            int pageNumber = 7;
            int navigatorSize = 6;

            // act
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            Assert.Equal(pagedList.Options.PageNumber, pageNumber);
            Assert.Equal(1, pagedList.Navigator.First.Number);
            Assert.Equal(
                urlAfterMountingWithoutPageNumber + "1",
                pagedList.Navigator.First.Url);
        }

        [Fact]
        public void PagedList_Construct_PageOptionsAndUrlNavigator_PreviousPage()
        {
            // arrange
            int itemCount = 347;
            int pageSize = 10;
            int pageNumber = 7;
            int navigatorSize = 6;

            // act
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            Assert.Equal(pagedList.Options.PageNumber, pageNumber);
            Assert.Equal(pageNumber - 1, pagedList.Navigator.Previous.Number);
            Assert.Equal(
                urlAfterMountingWithoutPageNumber + (pageNumber - 1).ToString(),
                pagedList.Navigator.Previous.Url);
        }

        [Fact]
        public void PagedList_Construct_PageOptionsAndUrlNavigator_NextPage()
        {
            // arrange
            int itemCount = 347;
            int pageSize = 10;
            int pageNumber = 7;
            int navigatorSize = 6;

            // act
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            Assert.Equal(pagedList.Options.PageNumber, pageNumber);
            Assert.Equal(pageNumber + 1, pagedList.Navigator.Next.Number);
            Assert.Equal(
                urlAfterMountingWithoutPageNumber + (pageNumber + 1).ToString(),
                pagedList.Navigator.Next.Url);
        }

        [Fact]
        public void PagedList_Construct_PageOptionsAndUrlNavigator_LastPage()
        {
            // arrange
            int itemCount = 347;
            int pageSize = 10;
            int pageNumber = 7;
            int navigatorSize = 6;
            int pageCount = 35;

            // act
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            Assert.Equal(pagedList.Options.PageNumber, pageNumber);
            Assert.Equal(pageCount, pagedList.Navigator.Last.Number);
            Assert.Equal(
                urlAfterMountingWithoutPageNumber + pageCount.ToString(),
                pagedList.Navigator.Last.Url);
        }

        [Fact]
        public void PagedList_Construct_UrlNavigator_NumericPages()
        {
            // arrange
            int itemCount = 347;
            int pageSize = 10;
            int pageNumber = 35;
            int navigatorSize = 6;

            // act
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            Assert.Equal(30, pagedList.Navigator.Numerics[0].Number);
            Assert.Equal(31, pagedList.Navigator.Numerics[1].Number);
            Assert.Equal(32, pagedList.Navigator.Numerics[2].Number);
            Assert.Equal(33, pagedList.Navigator.Numerics[3].Number);
            Assert.Equal(34, pagedList.Navigator.Numerics[4].Number);
            Assert.Equal(35, pagedList.Navigator.Numerics[5].Number);
        }

        [Fact]
        public void PagedList_Construct_UrlNavigator_FirstAndPreviousIsCurrent()
        {
            // arrange
            int itemCount = 347;
            int pageSize = 10;
            int pageNumber = 1;
            int navigatorSize = 6;

            // act
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            Assert.Null(pagedList.Navigator.First);
            Assert.Null(pagedList.Navigator.Previous);
        }

        [Fact]
        public void PagedList_Construct_UrlNavigator_LastAndNextIsCurrent()
        {
            // arrange
            int itemCount = 347;
            int pageSize = 10;
            int pageNumber = 35;
            int navigatorSize = 6;

            // act
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            Assert.Null(pagedList.Navigator.Last);
            Assert.Null(pagedList.Navigator.Next);
        }

        [Fact]
        public void PagedList_ToJson_WithUrlNavigator()
        {
            // arrange
            string minimalUrl = "";
            int itemCount = 100;
            int pageSize = 10;
            int pageNumber = 5;
            int navigatorSize = 3;

            // act
            PagedList pagedList = new PagedList(minimalUrl, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            string jsonExpected = "{\"options\":{\"pageNumber\":5,\"pageSize\":10,\"itemCount\":100,\"pageCount\":10},\"navigator\":{\"navigatorSize\":3,\"first\":{\"url\":\"?pageSize=10&pageNumber=1\",\"number\":1},\"previous\":{\"url\":\"?pageSize=10&pageNumber=4\",\"number\":4},\"next\":{\"url\":\"?pageSize=10&pageNumber=6\",\"number\":6},\"last\":{\"url\":\"?pageSize=10&pageNumber=10\",\"number\":10},\"numerics\":[{\"url\":\"?pageSize=10&pageNumber=4\",\"number\":4},{\"url\":\"?pageSize=10&pageNumber=5\",\"number\":5},{\"url\":\"?pageSize=10&pageNumber=6\",\"number\":6}]}}";
            string json = JsonConvert.SerializeObject(pagedList, jsonSerializer);
            Assert.Equal(json, jsonExpected);
        }

        [Fact]
        public void PagedList_ToJson_WithoutUrlNavigator()
        {
            // arrange
            string minimalUrl = "";
            int itemCount = 100;
            int pageSize = 10;
            int pageNumber = 5;

            // act
            PagedList pagedList = new PagedList(minimalUrl, itemCount, pageNumber, pageSize);

            // assert
            string jsonExpected = "{\"options\":{\"pageNumber\":5,\"pageSize\":10,\"itemCount\":100,\"pageCount\":10},\"navigator\":{\"navigatorSize\":null,\"first\":{\"url\":\"?pageSize=10&pageNumber=1\",\"number\":1},\"previous\":{\"url\":\"?pageSize=10&pageNumber=4\",\"number\":4},\"next\":{\"url\":\"?pageSize=10&pageNumber=6\",\"number\":6},\"last\":{\"url\":\"?pageSize=10&pageNumber=10\",\"number\":10},\"numerics\":null}}";
            string json = JsonConvert.SerializeObject(pagedList, jsonSerializer);
            Assert.Equal(json, jsonExpected);
        }
        
        [Fact]
        public void PagedList_ToJson_WithUrlNavigator_FirstPage()
        {
            // arrange
            string minimalUrl = "";
            int itemCount = 100;
            int pageSize = 10;
            int pageNumber = 1;
            int navigatorSize = 3;

            // act
            PagedList pagedList = new PagedList(minimalUrl, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            string jsonExpected = "{\"options\":{\"pageNumber\":1,\"pageSize\":10,\"itemCount\":100,\"pageCount\":10},\"navigator\":{\"navigatorSize\":3,\"first\":null,\"previous\":null,\"next\":{\"url\":\"?pageSize=10&pageNumber=2\",\"number\":2},\"last\":{\"url\":\"?pageSize=10&pageNumber=10\",\"number\":10},\"numerics\":[{\"url\":\"?pageSize=10&pageNumber=1\",\"number\":1},{\"url\":\"?pageSize=10&pageNumber=2\",\"number\":2},{\"url\":\"?pageSize=10&pageNumber=3\",\"number\":3}]}}";
            string json = JsonConvert.SerializeObject(pagedList, jsonSerializer);
            Assert.Equal(json, jsonExpected);
        }

        [Fact]
        public void PagedList_ToJson_WithUrlNavigator_LastPage()
        {
            // arrange
            string minimalUrl = "";
            int itemCount = 100;
            int pageSize = 10;
            int pageNumber = 10;
            int navigatorSize = 3;

            // act
            PagedList pagedList = new PagedList(minimalUrl, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            string jsonExpected = "{\"options\":{\"pageNumber\":10,\"pageSize\":10,\"itemCount\":100,\"pageCount\":10},\"navigator\":{\"navigatorSize\":3,\"first\":{\"url\":\"?pageSize=10&pageNumber=1\",\"number\":1},\"previous\":{\"url\":\"?pageSize=10&pageNumber=9\",\"number\":9},\"next\":null,\"last\":null,\"numerics\":[{\"url\":\"?pageSize=10&pageNumber=8\",\"number\":8},{\"url\":\"?pageSize=10&pageNumber=9\",\"number\":9},{\"url\":\"?pageSize=10&pageNumber=10\",\"number\":10}]}}";
            string json = JsonConvert.SerializeObject(pagedList, jsonSerializer);
            Assert.Equal(json, jsonExpected);
        }

        [Fact]
        public void PagedList_ToJson_WithUrlNavigator_OnlyPage()
        {
            // arrange
            string minimalUrl = "";
            int itemCount = 10;
            int pageSize = 10;
            int pageNumber = 1;
            int navigatorSize = 3;

            // act
            PagedList pagedList = new PagedList(minimalUrl, itemCount, pageNumber, pageSize, navigatorSize);

            // arrange 
            string jsonExpected = "{\"options\":{\"pageNumber\":1,\"pageSize\":10,\"itemCount\":10,\"pageCount\":1},\"navigator\":{\"navigatorSize\":3,\"first\":null,\"previous\":null,\"next\":null,\"last\":null,\"numerics\":[{\"url\":\"?pageSize=10&pageNumber=1\",\"number\":1}]}}";
            string json = JsonConvert.SerializeObject(pagedList, jsonSerializer);
            Assert.Equal(json, jsonExpected);
        }

        [Fact]
        public void PagedList_ToJson_WithUrlNavigator_EmptyItems()
        {
            // arrange
            string minimalUrl = "";
            int itemCount = 0;
            int pageSize = 10;
            int pageNumber = 1;
            int navigatorSize = 3;

            // act
            PagedList pagedList = new PagedList(minimalUrl, itemCount, pageNumber, pageSize, navigatorSize);

            // assert
            string jsonExpected = "{\"options\":{\"pageNumber\":1,\"pageSize\":10,\"itemCount\":0,\"pageCount\":0},\"navigator\":{\"navigatorSize\":3,\"first\":null,\"previous\":null,\"next\":null,\"last\":null,\"numerics\":null}}";
            string json = JsonConvert.SerializeObject(pagedList, jsonSerializer);
            Assert.Equal(json, jsonExpected);
        }
    }
}

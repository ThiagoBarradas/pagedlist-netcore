using PagedList.Models;
using System.Collections.Generic;
using Xunit;

namespace PagedList.Tests.Models
{
    public class UrlNavigatorTests
    {
        private string url = "http://www.myapp.com/";

        [Fact]
        public void UrlNavigator_Construct_FirstPage()
        {
            // arrange / act
            UrlNavigator nav = new UrlNavigator(url, 4, 10, null);
            PageLink page = nav.First;

            // assert
            Assert.Equal(page.Number, 1);
            Assert.Equal(page.Url, url+"?pageNumber=1");
        }

        [Fact]
        public void UrlNavigator_Construct_PreviousPage()
        {
            // arrange / act
            UrlNavigator nav = new UrlNavigator(url, 4, 10, null);
            PageLink page = nav.Previous;

            // assert
            Assert.Equal(page.Number, 3);
            Assert.Equal(page.Url, url + "?pageNumber=3");
        }

        [Fact]
        public void UrlNavigator_Construct_NextPage()
        {
            // arrange / act
            UrlNavigator nav = new UrlNavigator(url, 4, 10, null);
            PageLink page = nav.Next;

            // assert
            Assert.Equal(page.Number, 5);
            Assert.Equal(page.Url, url + "?pageNumber=5");
        }

        [Fact]
        public void UrlNavigator_Construct_LastPage()
        {
            // arrange / act
            UrlNavigator nav = new UrlNavigator(url, 4, 10, null);
            PageLink page = nav.Last;

            // assert
            Assert.Equal(page.Number, 10);
            Assert.Equal(page.Url, url + "?pageNumber=10");
        }

        [Fact]
        public void UrlNavigator_Construct_InvalidNavigatorSize()
        {
            // arrange / act
            UrlNavigator nav1 = new UrlNavigator(url, 4, 10, null);
            UrlNavigator nav2 = new UrlNavigator(url, 4, 10, 0);
            UrlNavigator nav3 = new UrlNavigator(url, 4, 10, -2);

            // assert
            Assert.Null(nav1.NavigatorSize);
            Assert.Null(nav1.Numerics);
            Assert.Null(nav2.NavigatorSize);
            Assert.Null(nav2.Numerics);
            Assert.Null(nav3.NavigatorSize);
            Assert.Null(nav3.Numerics);
        }

        [Fact]
        public void UrlNavigator_Construct_NavigatorSizeBiggerThenPageCount()
        {
            // arrange / act
            UrlNavigator nav = new UrlNavigator(url, 4, 8, 10);
            
            // assert
            Assert.Equal(nav.NavigatorSize, 10);
            Assert.Equal(nav.Numerics.Count, 8);            
        }

        [Fact]
        public void UrlNavigator_Construct_NumericPages()
        {
            // arrange / act
            UrlNavigator nav = new UrlNavigator(url, 37, 300, 10);
            List<PageLink> numPages = nav.Numerics;

            // assert
            Assert.Equal(nav.NavigatorSize, 10);
            Assert.Equal(nav.Numerics.Count, 10);
            Assert.Equal(numPages[9].Number, 42);
        }
    }
}

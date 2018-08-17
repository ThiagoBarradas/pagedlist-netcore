using PagedList.Models;
using PagedList.NetCore.Builders;
using System.Collections.Generic;
using Xunit;

namespace PagedList.NetCore.Tests.Builders
{
    public class UrlNavigatorBuilderTests
    {
        private string url = "http://www.myapp.com/";

        [Fact]
        public void UrlNavigator_Construct_FirstPage()
        {
            // arrange / act
            UrlNavigator nav = UrlNavigatorBuilder.Build(url, 4, 10, null);
            PageLink page = nav.First;

            // assert
            Assert.Equal(1, page.Number);
            Assert.Equal(page.Url, url+"?pageNumber=1");
        }

        [Fact]
        public void UrlNavigator_Construct_PreviousPage()
        {
            // arrange / act
            UrlNavigator nav = UrlNavigatorBuilder.Build(url, 4, 10, null);
            PageLink page = nav.Previous;

            // assert
            Assert.Equal(3, page.Number);
            Assert.Equal(page.Url, url + "?pageNumber=3");
        }

        [Fact]
        public void UrlNavigator_Construct_NextPage()
        {
            // arrange / act
            UrlNavigator nav = UrlNavigatorBuilder.Build(url, 4, 10, null);
            PageLink page = nav.Next;

            // assert
            Assert.Equal(5, page.Number);
            Assert.Equal(page.Url, url + "?pageNumber=5");
        }

        [Fact]
        public void UrlNavigator_Construct_LastPage()
        {
            // arrange / act
            UrlNavigator nav = UrlNavigatorBuilder.Build(url, 4, 10, null);
            PageLink page = nav.Last;

            // assert
            Assert.Equal(10, page.Number);
            Assert.Equal(page.Url, url + "?pageNumber=10");
        }

        [Fact]
        public void UrlNavigator_Construct_InvalidNavigatorSize()
        {
            // arrange / act
            UrlNavigator nav1 = UrlNavigatorBuilder.Build(url, 4, 10, null);
            UrlNavigator nav2 = UrlNavigatorBuilder.Build(url, 4, 10, 0);
            UrlNavigator nav3 = UrlNavigatorBuilder.Build(url, 4, 10, -2);

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
            UrlNavigator nav = UrlNavigatorBuilder.Build(url, 4, 8, 10);
            
            // assert
            Assert.Equal(10, nav.NavigatorSize);
            Assert.Equal(8, nav.Numerics.Count);
        }

        [Fact]
        public void UrlNavigator_Construct_NumericPages()
        {
            // arrange / act
            UrlNavigator nav = UrlNavigatorBuilder.Build(url, 37, 300, 10);
            List<PageLink> numPages = nav.Numerics;

            // assert
            Assert.Equal(10, nav.NavigatorSize);
            Assert.Equal(10, nav.Numerics.Count);
            Assert.Equal(42, numPages[9].Number);
        }
    }
}

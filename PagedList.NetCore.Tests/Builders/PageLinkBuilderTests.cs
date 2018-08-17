using PagedList.Models;
using PagedList.NetCore.Builders;
using Xunit;

namespace PagedList.NetCore.Tests.Builders
{
    public class PageLinkBuilderTests
    {
        [Fact]
        public void PageLink_Constructor_GenerateURLWithBaseUrl()
        {
            // arrange
            string url = "http://www.google.com";
            string urlreturn = "http://www.google.com?pageNumber=3";

            // act
            PageLink link = PageLinkBuilder.Build(url, 3);

            // assert
            Assert.Equal(urlreturn, link.Url);
        }

        [Fact]
        public void PageLink_Constructor_GenerateURLWithFullUrl()
        {
            // arrange
            string url = "http://www.google.com/xxx?test=123";
            string urlreturn = "http://www.google.com/xxx?test=123&pageNumber=3";

            // act
            PageLink link = PageLinkBuilder.Build(url, 3);

            // assert
            Assert.Equal(urlreturn, link.Url);
        }
        
        [Fact]
        public void PageLink_Constructor_GenerateURLWithQueryString()
        {
            // arrange
            string url = "?test=123";
            string urlreturn = "?test=123&pageNumber=3";

            // act
            PageLink link = PageLinkBuilder.Build(url, 3);

            // assert
            Assert.Equal(urlreturn, link.Url);
        }
    }
}

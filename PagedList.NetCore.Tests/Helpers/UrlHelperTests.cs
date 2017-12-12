using PagedList.Helpers;
using System;
using System.Collections.Specialized;
using Xunit;

namespace PagedList.NetCore.Tests.Helpers
{
    public class UrlHelperTests
    {
        [Fact]
        public void UrlHelper_GetUrlWithoutQueryString_UrlWithQueryString()
        {
            // arrange
            string urlWithQueryString = "http://www.google.com/test?param=value";
            string urlWithoutQueryString = "http://www.google.com/test";

            // act
            string urlReturned = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString);

            // assert
            Assert.Equal(urlReturned, urlWithoutQueryString);
        }

        [Fact]
        public void UrlHelper_GetUrlWithoutQueryString_UrlWithFlagQueryString()
        {
            // arrange
            string urlWithQueryString = "http://www.google.com/test?";
            string urlWithoutQueryString = "http://www.google.com/test";

            // act
            string urlReturned = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString);

            // assert
            Assert.Equal(urlReturned, urlWithoutQueryString);
        }

        [Fact]
        public void UrlHelper_GetUrlWithoutQueryString_UrlWithourQueryString()
        {
            // arrange
            string urlWithQueryString = "http://www.google.com/test";
            string urlWithoutQueryString = "http://www.google.com/test";

            // act
            string urlReturned = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString);

            // assert
            Assert.Equal(urlReturned, urlWithoutQueryString);
        }

        [Fact]
        public void UrlHelper_GetUrlWithoutQueryString_PartialUrlWithQueryString()
        {
            // arrange
            string urlWithQueryString = "/test?param=value";
            string urlWithoutQueryString = "/test";

            // acat
            string urlReturned = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString);

            // assert
            Assert.Equal(urlReturned, urlWithoutQueryString);
        }

        [Fact]
        public void UrlHelper_GetUrlWithoutQueryString_PartialUrlWithoutQueryString()
        {
            // arrange
            string urlWithQueryString = "test.asp";
            string urlWithoutQueryString = "test.asp";

            // act
            string urlReturned = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString);

            // assert
            Assert.Equal(urlReturned, urlWithoutQueryString);
        }

        [Fact]
        public void UrlHelper_GetUrlWithoutQueryString_OnlyQueryString()
        {
            // arrange
            string urlWithQueryString1 = "?param=value";
            string urlWithoutQueryString1 = "";
            string urlWithQueryString2 = "?";
            string urlWithoutQueryString2 = "";

            // act
            string urlReturned1 = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString1);
            string urlReturned2 = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString2);

            // assert
            Assert.Equal(urlReturned1, urlWithoutQueryString1);
            Assert.Equal(urlReturned2, urlWithoutQueryString2);
        }

        [Fact]
        public void UrlHelper_RemoveParameterFromQueryString_NotExistingParameter()
        {
            // arrange
            string urlWithParameter = "http://www.google.com/test?param=value&param2=value";
            string urlWithoutParameter = "http://www.google.com/test?param=value&param2=value";
            string[] parameters = { "param3" };

            // act
            string urlReturned = UrlHelper.RemoveParameterFromQueryString(urlWithParameter, parameters);

            // assert
            Assert.Equal(urlReturned, urlWithoutParameter);
        }

        [Fact]
        public void UrlHelper_RemoveParameterFromQueryString_ExistingParameterAndUrlFull()
        {
            // arrange
            string urlWithParameter = "http://www.google.com/test?param=value&param2=value";
            string urlWithoutParameter = "http://www.google.com/test?param2=value";
            string[] parameters = { "param" };

            // act
            string urlReturned = UrlHelper.RemoveParameterFromQueryString(urlWithParameter, parameters);

            // assert
            Assert.Equal(urlReturned, urlWithoutParameter);
        }

        [Fact]
        public void UrlHelper_RemoveParameterFromQueryString_ExistingParameterAndQueryString()
        {
            // arrange
            string urlWithParameter = "?param=value&param2=value";
            string urlWithoutParameter = "?param2=value";
            string[] parameters = { "param" };

            // act
            string urlReturned = UrlHelper.RemoveParameterFromQueryString(urlWithParameter, parameters);

            // assert
            Assert.Equal(urlReturned, urlWithoutParameter);
        }

        [Fact]
        public void UrlHelper_ParseQueryString_UrlFull()
        {
            // arrange
            string urlToConvert = "http://www.xyz.com?param=value&param2=value2";

            // act
            NameValueCollection collection = UrlHelper.ParseQueryString(urlToConvert);

            // assert
            Assert.Equal(collection.Count, 2);
            Assert.Equal(collection.Get("param"), "value");
            Assert.Equal(collection.Get("param2"), "value2");
        }

        [Fact]
        public void UrlHelper_ParseQueryString_QueryString()
        {
            // arrange
            string urlToConvert = "param=value&param2=value2";

            // act
            NameValueCollection collection = UrlHelper.ParseQueryString(urlToConvert);

            // assert
            Assert.Equal(collection.Count, 2);
            Assert.Equal(collection.Get("param"), "value");
            Assert.Equal(collection.Get("param2"), "value2");
        }

        [Fact]
        public void UrlHelper_ParseQueryString_WithoutParameter()
        {
            // arrange
            string urlToConvert1 = "http://www.xyz.com?";
            string urlToConvert2 = "http://www.xyz.com";

            // act
            NameValueCollection collection1 = UrlHelper.ParseQueryString(urlToConvert1);
            NameValueCollection collection2 = UrlHelper.ParseQueryString(urlToConvert2);

            // assert
            Assert.Equal(collection1.Count, 0);
            Assert.Equal(collection2.Count, 0);
        }

        [Fact]
        public void UrlHelper_ToParseQueryString_CollectionEmpty()
        {
            // arrange
            NameValueCollection collection = new NameValueCollection();

            // act
            string result = UrlHelper.ToQueryString(collection);

            // assert
            Assert.Equal(result, String.Empty);
        }

        [Fact]
        public void UrlHelper_ToParseQueryString_CollectionNotEmpty()
        {
            // arrange
            NameValueCollection collection = new NameValueCollection();
            collection.Add("param", "value");
            collection.Add("param2", "value2");

            // act
            string result = UrlHelper.ToQueryString(collection);

            // assert
            Assert.Equal(result, "param=value&param2=value2");
        }
    }
}

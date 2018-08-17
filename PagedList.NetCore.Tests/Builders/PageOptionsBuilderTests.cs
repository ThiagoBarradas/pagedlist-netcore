using PagedList.Models;
using PagedList.NetCore.Builders;
using Xunit;

namespace PagedList.NetCore.Tests.Builders
{
    public class PageOptionsBuilderTests
    {
        [Fact]
        public void PageOptions_Construct_Defaults()
        {
            // arrange / act
            PageOptions options = PageOptionsBuilder.Build(100);

            // assert
            Assert.Equal(1, options.PageNumber);
            Assert.Equal(10, options.PageSize);
        }

        [Fact]
        public void PageOptions_Construct_PageCount()
        {
            // arrange / act
            PageOptions options = PageOptionsBuilder.Build(100,1,5);

            // assert
            Assert.Equal(20, options.PageCount);
        }

        [Fact]
        public void PageOptions_Construct_InvalidItemCount()
        {
            // arrange / act
            PageOptions options = PageOptionsBuilder.Build(-100, 1, 5);

            // assert
            Assert.Equal(0, options.PageCount);
            Assert.Equal(0, options.ItemCount);
        }

        [Fact]
        public void PageOptions_Construct_InvalidPageNumber()
        {
            // arrange / act
            PageOptions options1 = PageOptionsBuilder.Build(100, 0, 5);
            PageOptions options2 = PageOptionsBuilder.Build(100, -5, 5);

            // assert
            Assert.Equal(1, options1.PageNumber);
            Assert.Equal(1, options2.PageNumber);
        }

        [Fact]
        public void PageOptions_Construct_InvalidPageSize()
        {
            // arrange / act
            PageOptions options1 = PageOptionsBuilder.Build(100, 1, 0);
            PageOptions options2 = PageOptionsBuilder.Build(100, 1, -5);

            // assert
            Assert.Equal(10, options1.PageSize);
            Assert.Equal(10, options2.PageSize);
        }

        [Fact]
        public void PageOptions_Construct_PageNumberOver()
        {
            // arrange / act
            PageOptions options = PageOptionsBuilder.Build(100, 25, 5);

            // assert
            Assert.Equal(options.PageNumber, options.PageCount);
            Assert.Equal(20, options.PageCount);
        }
    }
}

using PagedList.Models;
using Xunit;

namespace PagedList.Tests.Models
{
    public class PageOptionsTests
    {
        [Fact]
        public void PageOptions_Construct_Defaults()
        {
            // arrange / act
            PageOptions options = new PageOptions(100);

            // assert
            Assert.Equal(options.PageNumber, 1);
            Assert.Equal(options.PageSize, 10);
        }

        [Fact]
        public void PageOptions_Construct_PageCount()
        {
            // arrange / act
            PageOptions options = new PageOptions(100,1,5);

            // assert
            Assert.Equal(options.PageCount, 20);
        }

        [Fact]
        public void PageOptions_Construct_InvalidItemCount()
        {
            // arrange / act
            PageOptions options = new PageOptions(-100, 1, 5);

            // assert
            Assert.Equal(options.PageCount, 0);
            Assert.Equal(options.ItemCount, 0);
        }

        [Fact]
        public void PageOptions_Construct_InvalidPageNumber()
        {
            // arrange / act
            PageOptions options1 = new PageOptions(100, 0, 5);
            PageOptions options2 = new PageOptions(100, -5, 5);

            // assert
            Assert.Equal(options1.PageNumber, 1);
            Assert.Equal(options2.PageNumber, 1);
        }

        [Fact]
        public void PageOptions_Construct_InvalidPageSize()
        {
            // arrange / act
            PageOptions options1 = new PageOptions(100, 1, 0);
            PageOptions options2 = new PageOptions(100, 1, -5);

            // assert
            Assert.Equal(options1.PageSize, 10);
            Assert.Equal(options2.PageSize, 10);
        }

        [Fact]
        public void PageOptions_Construct_PageNumberOver()
        {
            // arrange / act
            PageOptions options = new PageOptions(100, 25, 5);

            // assert
            Assert.Equal(options.PageNumber, options.PageCount);
            Assert.Equal(20, options.PageCount);
        }
    }
}

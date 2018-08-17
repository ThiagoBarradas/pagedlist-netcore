using PagedList.Models;

namespace PagedList.NetCore.Builders
{
    internal class PageOptionsBuilder
    {
        public const int PAGE_NUMBER_DEFAULT = 1;

        public const int PAGE_SIZE_DEFAULT = 10;

        public static PageOptions Build(
            long itemCount, 
            int pageNumber = PageOptionsBuilder.PAGE_NUMBER_DEFAULT, 
            int pageSize = PageOptionsBuilder.PAGE_SIZE_DEFAULT)
        {
            var pageOptions = new PageOptions()
            {
                ItemCount = (itemCount < 0) ? 0 : itemCount,
                PageNumber = (pageNumber < 1) ? PageOptionsBuilder.PAGE_NUMBER_DEFAULT : pageNumber,
                PageSize = (pageSize < 1) ? PageOptionsBuilder.PAGE_SIZE_DEFAULT : pageSize,
            };

            PageOptionsBuilder.CalculatePageCount(pageOptions);
            PageOptionsBuilder.CheckPageNumber(pageOptions);

            return pageOptions;
        }

        private static void CalculatePageCount(PageOptions pageOptions)
        {
            int totalPages = (int)pageOptions.ItemCount / pageOptions.PageSize;
            if (pageOptions.ItemCount % pageOptions.PageSize != 0) totalPages++;
            pageOptions.PageCount = totalPages;
        }

        private static void CheckPageNumber(PageOptions pageOptions)
        {
            if (pageOptions.PageCount <= 0)
            {
                pageOptions.PageNumber = 1;
            }
            else if (pageOptions.PageNumber > pageOptions.PageCount)
            {
                pageOptions.PageNumber = pageOptions.PageCount;
            }
        }
    }
}

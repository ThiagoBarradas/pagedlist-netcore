using PagedList.Helpers;
using PagedList.Models;
using PagedList.NetCore.Builders;

namespace PagedList
{
    public class PagedList
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public PagedList() { }

        /// <summary>
        /// Contructor - Set configuration for mounting paged list
        /// </summary>
        /// <param name="OriginUrl">Origin url - full or only path</param>
        /// <param name="itemCount">Items count total </param>
        /// <param name="pageNumber">Current page</param>
        /// <param name="pageSize">Page max size</param>
        /// <param name="navigatorSize">Numeric navigator size, if null, this is not generated </param>
        public PagedList(
            string originUrl,
            long itemCount,
            int pageNumber,
            int pageSize,
            int? navigatorSize = null
        )
        {
            this.Options = PageOptionsBuilder.Build(itemCount, pageNumber, pageSize);
            originUrl = UrlHelper.GetUrlBaseToPagingWithoutPagingParams(originUrl, pageSize);
            this.Navigator = UrlNavigatorBuilder.Build(originUrl, Options.PageNumber, Options.PageCount, navigatorSize);
        }

        public PageOptions Options { get; set; }

        public UrlNavigator Navigator { get; set; }
    }
}
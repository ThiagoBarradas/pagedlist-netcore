using PagedList.Helpers;
using PagedList.Models;

namespace PagedList
{
    public class PagedList
    {

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
            int pageNumber = PageOptions.PAGE_NUMBER_DEFAULT,
            int pageSize = PageOptions.PAGE_SIZE_DEFAULT,
            int? navigatorSize = null
        )
        {
            this.Options = new PageOptions(itemCount, pageNumber, pageSize);
            originUrl = this.GetUrlBaseToPaging(originUrl, pageSize);
            this.Navigator = new UrlNavigator(originUrl, Options.PageNumber, Options.PageCount, navigatorSize);
        }

        public PageOptions Options { get; private set; }

        public UrlNavigator Navigator { get; private set; }

        private string GetUrlBaseToPaging(string url, int pageSize)
        {
            string[] parameters = { "pageNumber", "pageSize" };
            url = UrlHelper.RemoveParameterFromQueryString(url, parameters);

            if (!url.Contains("?"))
                url += "?";
            else if (url.Contains("?") && url.IndexOf("?") == (url.Length - 1))
                url += "";
            else
                url += "&";

            return url + "pageSize=" + pageSize.ToString();
        }
    }
}
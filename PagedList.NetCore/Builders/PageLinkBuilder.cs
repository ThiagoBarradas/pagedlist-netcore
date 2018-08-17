using PagedList.Models;

namespace PagedList.NetCore.Builders
{
    internal class PageLinkBuilder
    {
        public static PageLink Build(string url, int pageNumber)
        {
            var newUrl = url + ((url.Contains("?")) ? "&" : "?");
            newUrl = newUrl + "pageNumber=" + pageNumber.ToString();

            return new PageLink()
            {
                Number = pageNumber,
                Url = newUrl
            };
        }
    }
}

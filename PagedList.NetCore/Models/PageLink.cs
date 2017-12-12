namespace PagedList.Models
{
    public class PageLink
    {
        public PageLink(string url, int pageNumber)
        {
            this.Number = pageNumber;

            url += (url.Contains("?")) ? "&" : "?" ;

            this.Url = url + "pageNumber=" + pageNumber.ToString();
        }

        public string Url { get; private set; }

        public int Number { get; private set; }
    }
}

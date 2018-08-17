namespace PagedList.Models
{
    public class PageOptions
    {   
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public long ItemCount { get; set; }

        public int PageCount { get; set; }
    }
}

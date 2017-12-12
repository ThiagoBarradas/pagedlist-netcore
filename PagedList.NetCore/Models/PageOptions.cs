namespace PagedList.Models
{
    public class PageOptions
    {
        public PageOptions(long itemCount, int pageNumber = PAGE_NUMBER_DEFAULT, int pageSize = PAGE_SIZE_DEFAULT)
        {
            
            this.ItemCount = itemCount;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.CalculatePageCount();
            this.CheckPageNumber();
        }

        public const int PAGE_NUMBER_DEFAULT = 1;

        public const int PAGE_SIZE_DEFAULT = 10;

        private int _pageNumber;
        
        public int PageNumber 
        {
            get { return _pageNumber; }
            private set {
                _pageNumber = (value<1) ? PAGE_NUMBER_DEFAULT : value ;
            }
        }

        private int _pageSize;

        public int PageSize
        {
            get { return _pageSize; }
            private set
            {
                _pageSize = (value < 1) ? PAGE_SIZE_DEFAULT : value;
            }
        }

        private long _itemCount;

        public long ItemCount
        {
            get { return _itemCount; }
            private set
            {
                _itemCount = (value < 0) ? 0 : value;
            }
        }

        public int PageCount { get; private set; }

        private void CalculatePageCount() {

            int totalPages = (int)this.ItemCount / this.PageSize;

            if (this.ItemCount % this.PageSize != 0) totalPages++;

            this.PageCount = totalPages;
        }

        private void CheckPageNumber()
        {
            if (this.PageNumber > this.PageCount) 
            {
                this.PageNumber = this.PageCount;
            }
        }
    }
}

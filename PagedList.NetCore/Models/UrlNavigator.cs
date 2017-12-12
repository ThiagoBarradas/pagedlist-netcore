using System.Collections.Generic;

namespace PagedList.Models
{
    public class UrlNavigator
    {
        public UrlNavigator(string url, int pageNumber, int pageCount, int? navigatorSize) {

            this.PageNumber = pageNumber;
            this.PageCount = pageCount;
            this.Url = url;

            if (navigatorSize != null && navigatorSize > 0) 
            {
                this.NavigatorSize = navigatorSize;
                GenerateNumericNavigation();
            }

            GenerateBasicNavigation();
        }

        private int PageNumber;

        private int PageCount;

        private string Url;

        public int? NavigatorSize { get; private set; }

        public PageLink First { get; private set; }
        
        public PageLink Previous { get; private set; }

        public PageLink Next { get; private set; }
        
        public PageLink Last { get; private set; }

        public List<PageLink> Numerics { get; private set; }

        private void GenerateBasicNavigation() { 
            if (this.PageNumber != 1)
            {
                this.First = new PageLink(Url, 1);

                int previousNumber = this.PageNumber - 1;
                this.Previous = new PageLink(this.Url, previousNumber);
            }

            if (this.PageNumber != this.PageCount && this.PageCount != 0)
            {
                int nextNumber = this.PageNumber + 1;
                Next = new PageLink(this.Url, nextNumber);

                Last = new PageLink(this.Url, this.PageCount);
            }
        }

        public void GenerateNumericNavigation() 
        {
            if (this.PageCount == 0) return;

            int[] limits = this.GetComplexLimits();
            
            int start = limits[0];
            int end = limits[1];

            this.Numerics = new List<PageLink>();

            for(int i=start; i<=end; i++)
            {
                this.Numerics.Add( new PageLink(Url, i) );
            }
        }

        public int[] GetComplexLimits() {

            if(this.PageCount <= this.NavigatorSize)
            {
                return new int[] { 1 , this.PageCount };
            }

            int pageNumberPositionRelativeOfStart = this.PageNumber - 1;
            int pageNumberPositionRelativeOfEnd = this.PageCount - this.PageNumber;
                
            int leftNavigationSize = (int)NavigatorSize / 2;
            int rightNavigationSize = (int)this.NavigatorSize / 2;
                
            if (this.NavigatorSize % 2 == 0 && leftNavigationSize>0)
                leftNavigationSize--;

            if (leftNavigationSize >= pageNumberPositionRelativeOfStart)
            {
                return new int[] { 1, (int)this.NavigatorSize };
            }
            else if (rightNavigationSize >= pageNumberPositionRelativeOfEnd) 
            {
                return new int[] { this.PageCount - ((int)this.NavigatorSize - 1), this.PageCount };
            }
            else 
            {
                return new int[] { this.PageNumber - leftNavigationSize, this.PageNumber + rightNavigationSize };
            }
        }
    }
}

using System.Collections.Generic;

namespace PagedList.Models
{
    public class UrlNavigator
    {
        public int? NavigatorSize { get; set; }

        public PageLink First { get; set; }
        
        public PageLink Previous { get; set; }

        public PageLink Next { get; set; }
        
        public PageLink Last { get; set; }

        public List<PageLink> Numerics { get; set; }
    }
}

using PagedList.Models;
using System.Collections.Generic;

namespace PagedList.NetCore.Builders
{
    internal class UrlNavigatorBuilder
    {
        public static UrlNavigator Build(string url, int pageNumber, int pageCount, int? navigatorSize)
        {
            if (navigatorSize != null && navigatorSize < 1)
            {
                navigatorSize = null;
            }

            var urlNavigator = new UrlNavigator()
            {
                Numerics = UrlNavigatorBuilder.GenerateNumericNavigation(navigatorSize, pageCount, pageNumber, url),
                NavigatorSize = navigatorSize
            };

            UrlNavigatorBuilder.GenerateBasicNavigation(urlNavigator, pageCount, pageNumber, url);

            return urlNavigator;
        }

        private static void GenerateBasicNavigation(UrlNavigator urlNavigator, int pageCount, int pageNumber, string url)
        {
            if (pageNumber > 1)
            {
                urlNavigator.First = PageLinkBuilder.Build(url, 1);

                int previousNumber = pageNumber - 1;
                urlNavigator.Previous = PageLinkBuilder.Build(url, previousNumber);
            }

            if (pageNumber != pageCount && pageCount != 0)
            {
                int nextNumber = pageNumber + 1;
                urlNavigator.Next = PageLinkBuilder.Build(url, nextNumber);

                urlNavigator.Last = PageLinkBuilder.Build(url, pageCount);
            }
        }

        public static List<PageLink> GenerateNumericNavigation(int? navigatorSize, int pageCount, int pageNumber, string url)
        {
            if (navigatorSize == null || navigatorSize == 0)
            {
                return null;
            }

            if (pageCount == 0)
            {
                return null;
            }

            int[] limits = UrlNavigatorBuilder.GetComplexLimits(navigatorSize, pageCount, pageNumber);

            int start = limits[0];
            int end = limits[1];

            var numerics = new List<PageLink>();

            for (int i = start; i <= end; i++)
            {
                numerics.Add(PageLinkBuilder.Build(url, i));
            }

            return numerics;
        }

        public static int[] GetComplexLimits(int? navigatorSize, int pageCount, int pageNumber)
        {

            if (pageCount <= (navigatorSize ?? 0))
            {
                return new int[] { 1, pageCount };
            }

            int pageNumberPositionRelativeOfStart = pageNumber - 1;
            int pageNumberPositionRelativeOfEnd = pageCount - pageNumber;

            int leftNavigationSize = (int)navigatorSize / 2;
            int rightNavigationSize = (int)navigatorSize / 2;

            if (navigatorSize % 2 == 0 && leftNavigationSize > 0)
                leftNavigationSize--;

            if (leftNavigationSize >= pageNumberPositionRelativeOfStart)
            {
                return new int[] { 1, (int)navigatorSize };
            }
            else if (rightNavigationSize >= pageNumberPositionRelativeOfEnd)
            {
                return new int[] { pageCount - ((int)navigatorSize - 1), pageCount };
            }
            else
            {
                return new int[] { pageNumber - leftNavigationSize, pageNumber + rightNavigationSize };
            }
        }
    }
}

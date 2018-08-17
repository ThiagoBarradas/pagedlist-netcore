using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PagedList.NetCore.Tests")]
namespace PagedList.Helpers
{
    internal static class UrlHelper
    {
        public static string GetUrlBaseToPagingWithoutPagingParams(string url, int pageSize)
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

        public static string GetUrlWithoutQueryString(string url)
        {
            if(!(url.Contains("?") || url.Contains("&"))) 
            {
                return url;
            }
            else if((url.Contains("&") && !url.Contains("?")) || (url.Contains("?") && url.IndexOf("?")==0))
            {
                return String.Empty;
            }
            else
            {
                int startPositionQueryString = url.IndexOf("?");

                int endPostionUrlBase = (startPositionQueryString >= 0) ? startPositionQueryString : url.Length;

                return url.Substring(0, endPostionUrlBase);
            }
        }

        public static string RemoveParameterFromQueryString(string url, string[] parameters = null)
        {
            if (url.Contains("?") || url.Contains("&")) { 
                
                NameValueCollection collection = ParseQueryString(url);

                foreach(string parameter in parameters) {
                    collection.Remove(parameter);
                }

                return GetUrlWithoutQueryString(url) + "?" + ToQueryString(collection);
            }
            else 
            {
                return url;
            }
        }

        public static NameValueCollection ParseQueryString(string querystring)
        {
            NameValueCollection collection = new NameValueCollection();

            if (querystring.Contains("?"))
            {
                querystring = querystring.Substring(querystring.IndexOf('?') + 1);
            }

            if (querystring.Trim().Length == 0 || !(querystring.Contains("?") || querystring.Contains("&") || querystring.Contains("=")))
                return collection;

            foreach (string parameters in Regex.Split(querystring, "&"))
            {
                string[] singlePair = Regex.Split(parameters, "=");

                if (singlePair.Length == 2)
                {
                    collection.Add(singlePair[0], singlePair[1]);
                }
                else 
                {
                    collection.Add(singlePair[0], string.Empty);
                }
            }

            return collection;
        }

        public static string ToQueryString(NameValueCollection collection)
        {		
            string querystring = String.Empty;

            for(int i=0; i < collection.Count ; i++)
            {
                string key = collection.GetKey(i);

                var values = collection.GetValues(i);
                
                foreach (var value in values) 
                {
                    if (!String.IsNullOrWhiteSpace(querystring)) querystring += "&";

                    querystring += key + "=" + value;
                }
            }
            
            return querystring;
        }
    }
}

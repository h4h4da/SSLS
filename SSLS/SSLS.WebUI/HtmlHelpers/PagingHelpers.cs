using SSLS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SSLS.WebUI.HtmlHelpers
{
    public static class PagingHelpers {

        public static MvcHtmlString PageLink(this HtmlHelper html, PagingInfo paginginfo, Func<int, string> pageUrl)
        {

            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= paginginfo.TotalPages; i++)
            {
                TagBuilder tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", pageUrl(i));
                tagBuilder.InnerHtml = i.ToString();
                if (i == paginginfo.CurrentPage)
                {
                    result.Append("<li class='active'>" + tagBuilder.ToString() + "</li>");
                }
                else {
                    result.Append("<li>" + tagBuilder.ToString() + "</li>");
                }
              
                
               

            }

            return MvcHtmlString.Create("<nav> <ul class='pagination'>" + result.ToString() + "</ul ></nav>");

        }

    }
   
}
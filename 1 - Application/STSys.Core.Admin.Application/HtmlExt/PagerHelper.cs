using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.HtmlExt
{
    public static class PagerHelper
    {
        private const string REQUEST_PAGEINDEX_NAME = "pageIndex";
        private const int PAGEER_COUNT = 5;
        private static string oldFormatPager = "javascript:to_page({0});";
        private static string gotoPager = string.Empty;

        public static HtmlString AjaxPager(this IHtmlHelper html, int pageSize, int totalCount, int? currentPage = null, string formatPager = "")
        {
            if(string.IsNullOrEmpty(formatPager))
                formatPager = "javascript:to_page({0});";
            gotoPager = "javascript:gotopage();";
            return GeneratePager(html, pageSize, totalCount, currentPage, formatPager);
        }

        private static HtmlString GeneratePager(IHtmlHelper html, int pageSize, int totalCount, int? currentPage = null, string formatPager = "")
        {
            var totalPagesCount = Math.Max((totalCount + pageSize - 1) / pageSize, 1);
            if (totalPagesCount <= 1) return null;
            var currentPageIndex = currentPage ?? GetCurrentPage(html, totalPagesCount);
            var output = new StringBuilder();
            output.Append("<div class=\"btn-group\">");

            //上一页
            HandleFirstPage(output, currentPageIndex, formatPager);
            //
            //HandlePreviousPage(output, currentPageIndex);
            //当前页
            HandlePagers(output, totalPagesCount, currentPageIndex, formatPager);
            //下一页
            //HandleNextPage(output, totalPagesCount, currentPageIndex);
            HandleLastPage(output, totalPagesCount, currentPageIndex, formatPager);
            output.Append("</div>");

            return new HtmlString(output.ToString());
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="output"></param>
        /// <param name="currentPageIndex"></param>
        private static void HandleFirstPage(StringBuilder output, int currentPageIndex,string formatPager)
        {
            if (currentPageIndex == 1)
            {
                output.AppendFormat("<a  class=\"btn btn-white\"><i class=\"fa fa-chevron-left\"></i></a>");
            }
            else
            {
                output.AppendFormat("<a  class=\"btn btn-white\" href=\"{0}\"><i class=\"fa fa-chevron-left\"></i></a>", GetAHref(currentPageIndex-1, formatPager));
            }

        }
        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="output"></param>
        /// <param name="totalPagesCount"></param>
        /// <param name="currentPageIndex"></param>
        private static void HandleLastPage(StringBuilder output, int totalPagesCount, int currentPageIndex,string formatPager)
        {
            if (currentPageIndex < totalPagesCount)
            {
                output.AppendFormat("<a href=\"{0}\" class=\"btn btn-white\"><i class=\"fa fa-chevron-right\"></i></a>", GetAHref(currentPageIndex+1, formatPager));
               
            }
            else
            {
                output.Append("<a href=\"javascript: void(0)\"  class=\"btn btn-white\"><i class=\"fa fa-chevron-right\"></i></a>");
            }
        }
        private static void HandlePreviousPage(StringBuilder output, int currentPageIndex, string formatPager)
        {
            if (currentPageIndex == 1)
            {
                output.Append("<li class=\"disabled\"><a href=\"javascript:void(0);\" class=\"paginate_button previous\" id=\"datatable1_previous\">上一页</a></li>");
            }
            else
            {
                output.AppendFormat("<li><a href=\"{0}\" class=\"paginate_button previous\">上一页</a></li>", GetAHref(currentPageIndex - 1, formatPager));
            }
        }



        private static void HandlePagers(StringBuilder output, int totalPagesCount, int currentPageIndex,string formatPager)
        {
            int startIndex = GetStartIndex(totalPagesCount, currentPageIndex);

            for (var i = 0; i < PAGEER_COUNT; i++)
            {
                int pageIndex = startIndex + i;

                if (pageIndex > totalPagesCount) break;
                if (currentPageIndex == pageIndex)
                {
                    output.AppendFormat("<a href=\"javascript: void(0)\" class=\"btn btn-white  active\">{0}</a>", pageIndex);
                }
                else
                {
                    output.AppendFormat(" <a href=\"{0}\" class=\"btn btn-white \">{1}</a>",  GetAHref(pageIndex, formatPager), pageIndex);
                }

            }
        }

        private static void HandleNextPage(StringBuilder output, int totalPagesCount, int currentPageIndex, string formatPager)
        {

            if (currentPageIndex < totalPagesCount)
            {
                output.AppendFormat("<li><a href=\"{0}\" class=\"paginate_button next\">下一页</a></li>", GetAHref(currentPageIndex + 1, formatPager));

            }
            else
            {
                output.Append("<li  class=\"disabled\"><a href=\"javascript:void(0);\" class=\"paginate_button next\">下一页</a></li>");
            }
        }


        private static int GetCurrentPage(IHtmlHelper html, int totalPagesCount)
        {
            var currentPageIndex = 0;
            if (html.ViewContext.HttpContext.Request.Method == "POST")
            {
                var queryString = html.ViewContext.HttpContext.Request.Form;
                int.TryParse(queryString[REQUEST_PAGEINDEX_NAME], out currentPageIndex);
            }
            else
            {
                var queryString = html.ViewContext.HttpContext.Request.Query;
                int.TryParse(queryString[REQUEST_PAGEINDEX_NAME], out currentPageIndex);
            }
            if (currentPageIndex == 0) currentPageIndex = 1;
            if (currentPageIndex > totalPagesCount)
                currentPageIndex = totalPagesCount;
            return currentPageIndex;
        }

        private static int GetStartIndex(int totalPagesCount, int currentPage)
        {
            var leftEdge = currentPage - PAGEER_COUNT / 2;
            var startIndex = leftEdge <= 0 ? 1 : leftEdge;
            var rightEdge = startIndex - 1 + PAGEER_COUNT;
            if (totalPagesCount >= PAGEER_COUNT && rightEdge > totalPagesCount) startIndex -= rightEdge - totalPagesCount;

            return startIndex;
        }


        private static string GetAHref(int pageIndex,string formatPager)
        {
            return string.Format(formatPager, pageIndex);
        }

    }
}

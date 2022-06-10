using System;
using System.Collections.Generic;

namespace OngProject.Core.Models
{
    public class PageList<T> where T : class
    {
        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPage { get; private set; }
        public string NextPage { get; private set; }
        public string PreviusPage { get; private set; }
        public string URL { get; private set; }

        public List<T> Items { get; private set; }

        public PageList(List<T> items, int page, int pageSize, int totalItems, string url)
        {
            Page = page;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPage = (int)Math.Ceiling(TotalItems / (double)PageSize);
            URL = url;

            if (page > 1)
                PreviusPage = $"{URL}?page={page - 1}";

            if (page < TotalPage)
                NextPage = $"{URL}?page={page + 1}";

            Items = items;
        }
    }
}

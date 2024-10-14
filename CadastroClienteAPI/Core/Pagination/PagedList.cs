using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pagination
{
    public class PagedList<T> : List<T>
    {
        public PagedList(int pageNumber, int count, int pageSize, IEnumerable<T> items)
        {
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
            TotalCount = count;
            PageSize = pageSize;

            AddRange(items);
        }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }


    }
}

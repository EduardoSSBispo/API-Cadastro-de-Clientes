using Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static class PaginationHelper
    {
        public static PagedList<T> Create<T>(IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            var count = source.Count();

            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(pageNumber, count, pageSize, items);
        }
    }
}

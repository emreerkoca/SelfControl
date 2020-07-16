using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Self.Infrastructure.Data.Paging
{
    public class PagedItemList<T> : List<T>
    {
        public int CurrentPageIndex { get; private set; }
        public int TotalPageCount { get; private set; }
        public int PageItemCount { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPreviousPage => CurrentPageIndex > 1;
        public bool HasNextPage => CurrentPageIndex < TotalPageCount;

        public PagedItemList(List<T> items, int pageIndex, int pageItemCount, int count)
        {
            CurrentPageIndex = pageIndex;
            PageItemCount = pageItemCount;
            TotalCount = count;
            TotalPageCount = (int)Math.Ceiling(count / (double)pageItemCount);

            AddRange(items);
        }

        public static PagedItemList<T> ToPagedItemList(IQueryable<T> source, int pageIndex, int pageItemCount)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageItemCount).Take(pageItemCount).ToList();

            return new PagedItemList<T>(items, count, pageIndex, pageItemCount);
        }
    }
}

using Self.Core.Entities;
using Self.Core.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Self.Core.DTOs
{
    public class ItemListDTO<T>
    {
        public int PageCount { get; set; }
        public PagedItemList<T> ItemList { get; set; }
    }
}

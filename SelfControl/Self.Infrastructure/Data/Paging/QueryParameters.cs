using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Infrastructure.Data
{
    public class QueryParameters
    {
        const int maxPageSize = 30;
        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}

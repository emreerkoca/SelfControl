using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Core.Paging
{
    public class PagingParameters
    {
        const int maxItemCount = 30;
        public int PageIndex { get; set; } = 1;

        private int itemCount = 10;
        public int ItemCount
        {
            get
            {
                return itemCount;
            }
            set
            {
                itemCount = (value > maxItemCount) ? maxItemCount : value;
            }
        }
    }
}

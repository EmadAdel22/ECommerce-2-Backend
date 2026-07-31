using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.core.Sharing
{
    public class ProducParams
    {
        //string sort, int? CategoryId, int PageNumber, int pageSize

        public string? sort {  get; set; }

        public int? CategoryId { get; set; }

        public string search { get; set; }
        public int maxPageSize { get; set; } = 6;
        private int _pageSize = 3;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize =  value > maxPageSize? maxPageSize : value; }
        }

        public int PageNumbre { get; set; } = 1;
        



    }
}

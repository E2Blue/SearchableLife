using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchableLife.Data.Queries
{
    public class GenericQuery
    {
        public string Query { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}

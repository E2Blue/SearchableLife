using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchableLife.Domain.Collections
{
    /// <summary>
    /// used for creating paged lists
    /// </summary>
    /// <typeparam name="t">The type the list should contain</typeparam>
    public class PagedList<t> : List<t>
    {
        /// <summary>
        /// The requested pagesize
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// The total count of items in data storage matching a criteria
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// the index of the current page
        /// </summary>
        public int PageIndex { get; set; }

        public PagedList(IEnumerable<t> items)
        {
            AddRange(items);
        }
    }
}

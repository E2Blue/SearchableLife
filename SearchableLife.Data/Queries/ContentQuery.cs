using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchableLife.Data.Queries
{
    public class ContentQuery : QueryBase
    {
        /// <summary>
        /// Currently only supports searching by a single tag
        /// </summary>
        public String TagName { get; set; }
    }
}

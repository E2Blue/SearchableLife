using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchableLife.Data.Queries
{
    public class TagQuery : GenericQuery
    {
        public List<String> TagNames { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchableLife.Domain.Interface
{
    /// <summary>
    /// Used fo retrieving an items title and route
    /// </summary>
    public interface IRoutable
    {
        string Title { get; set; }

        string Slug { get; set; }
    }
}

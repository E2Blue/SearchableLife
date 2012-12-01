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
        /// <summary>
        /// The title of the item
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// The route used to access the item, must be unique per contenttype and can be used as an id
        /// </summary>
        string Slug { get; set; }
    }
}

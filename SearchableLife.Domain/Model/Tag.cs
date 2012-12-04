using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchableLife.Domain.Interface;

namespace SearchableLife.Domain.Model
{
    /// <summary>
    /// The basis of the system, used to tag content to enable searching.
    /// </summary>
    [Serializable]
    public class Tag : IRoutable, IMenuItem
    {
        #region IMenuItem
        public string MenuTitle { get; set; }

        public string MenuDescription { get; set; }
        #endregion

        #region IRoutable
        public string Title { get; set; }

        public string Slug { get; set; }
        #endregion
    }
}

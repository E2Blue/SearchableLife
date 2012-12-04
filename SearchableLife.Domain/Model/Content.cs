using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchableLife.Domain.Interface;

namespace SearchableLife.Domain.Model
{
    public abstract class Content : IRoutable
    {
        #region IRoutable
        public string Title { get; set; }

        public string Slug { get; set; }
        #endregion

        /// <summary>
        /// The Html content of the item
        /// </summary>
        public string HtmlContent { get; set; }
    }
}

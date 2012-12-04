using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchableLife.Domain.Interface;
using System.Web.Mvc;

namespace SearchableLife.Domain.Model
{
    public abstract class Content : IRoutable, ITaggable
    {
        #region IRoutable
        public string Title { get; set; }

        public string Slug { get; set; }
        #endregion

        #region ITaggable
        public List<string> TagNames { get; set; }
        #endregion

        /// <summary>
        /// The Html content of the item
        /// </summary>
        [AllowHtml()]
        public string HtmlContent { get; set; }

        public DateTime Created { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchableLife.Domain.Interface;

namespace SearchableLife.Domain.Model
{
    public class Content : IRoutable, ITaggable
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
        public string HtmlContent { get; set; }

        /// <summary>
        /// Contains an entry for each time the content was updated
        /// </summary>
        public List<DateTime> Updated { get; set; }
    }
}

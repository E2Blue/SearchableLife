using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchableLife.Domain.Interface;

namespace SearchableLife.Domain.Model
{
    /// <summary>
    /// Used to combine contents with specific tags for display, ie Malta2011 + Travel
    /// </summary>
    [Serializable]
    public class TagAggregator: Content, IMenuItem
    {
        #region IMenuItem
        public string MenuTitle { get; set; }

        public string MenuDescription { get; set; }

        public string MenuImageUrl { get; set; }
        #endregion

        public List<Tag> AggragatedTags { get; set; }
    }
}

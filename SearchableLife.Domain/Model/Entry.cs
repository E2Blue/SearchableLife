using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchableLife.Domain.Interface;

namespace SearchableLife.Domain.Model
{
    /// <summary>
    /// A entry, can be thought of as a blogpost or facebook status or whatever
    /// </summary>
    [Serializable]
    public class Entry: Content, ITaggable
    {
        public List<string> TagNames { get; set; }
    }
}

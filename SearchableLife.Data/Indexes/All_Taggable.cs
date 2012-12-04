using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Indexes;
using SearchableLife.Domain.Model;

namespace SearchableLife.Data.Indexes
{
    public class All_Taggable : AbstractMultiMapIndexCreationTask
    {
        public All_Taggable()
        {
            AddMap<Entry>(entries => entries.Select(e => new
            {
                e.TagNames
            }));

            AddMap<Media>(media => media.Select(m => new
            {
                m.TagNames
            }));
        }
    }
}

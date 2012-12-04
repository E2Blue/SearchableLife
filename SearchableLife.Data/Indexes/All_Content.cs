using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Indexes;
using SearchableLife.Domain.Model;

namespace SearchableLife.Data.Indexes
{
    public class All_Content : AbstractMultiMapIndexCreationTask
    {
        public All_Content()
        {
            AddMap<Entry>(entries => entries.Select(e => new
            {
                e.Slug,
                e.Title,
            }));

            AddMap<Tag>(tags => tags.Select(t => new
            {
                t.Slug,
                t.Title,
            }));
        }
    }
}

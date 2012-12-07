using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchableLife.Domain.Interface
{
    public interface IMenuItem
    {
        string MenuTitle { get; set; }

        string MenuDescription { get; set; }

        string MenuImageUrl { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchableLife.Domain.Interface;

namespace SearchableLife.Domain.Model
{
    /// <summary>
    /// Used to save media such as video and images
    /// </summary>
    [Serializable]
    public class Media: IRoutable, ITaggable
    {
    }
}

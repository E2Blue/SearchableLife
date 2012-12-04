using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchableLife.Domain.Helpers
{
    public static class StringHelper
    {
        public static List<string> csStringTo(string csValues)
        {
            List<string> values = new List<string>();
            if (!string.IsNullOrEmpty(csValues))
            {
                values.AddRange(csValues.Split(','));
                for (int i = 0; i < values.Count; i++)
                {
                    values[i] = values[i].Trim(' ');
                }
            }
            return values;
        }
    }
}

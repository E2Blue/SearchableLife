using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SearchableLife.Web.Helpers
{
    public static class StringHelper
    {
        public static string StripHtml(this string input)
        {
            input = Regex.Replace(input, "<[^>]*(>|$)", string.Empty);
            input = Regex.Replace(input,@"[\s\r\n]+"," ");
            return input;
        }

        public static string Ellipsis(this string input,int length)
        {
            if(input.Length > length)
            {
                input = input.Remove(length);
                input += "...";
            }
            return input;
        }

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
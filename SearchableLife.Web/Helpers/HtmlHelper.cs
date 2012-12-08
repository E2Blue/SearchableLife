using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelpers
    {
        public static string ColorFromLetter(this HtmlHelper helper, string input)
        {
            if (input.Length > 0)
            {
                int firstLetterAscii = input.ToLower()[0];
                if (firstLetterAscii > 120)
                    return "teal";
                else if (firstLetterAscii > 118)
                    return "pink";
                else if (firstLetterAscii > 116)
                    return "lime";
                else if (firstLetterAscii > 114)
                    return "magenta";
                else if (firstLetterAscii > 111)
                    return "red";
                else if (firstLetterAscii > 108)
                    return "purple";
                else if (firstLetterAscii > 105)
                    return "orange";
                else if (firstLetterAscii > 102)
                    return "green";
                else if (firstLetterAscii > 99)
                    return "brown";
                else if (firstLetterAscii > 96)
                    return "blue";







            }
            return "";
        }
    }
}
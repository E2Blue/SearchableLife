using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchableLife.Domain.Model;

namespace SearchableLife.Web.Areas.Admin.ViewModels
{
    public class EntryVM
    {
        public Entry Model { get; set; }

        [AllowHtml]
        public string HtmlContent
        {
            get { return Model.HtmlContent; }
            set { Model.HtmlContent = value; }
        }
    }
}
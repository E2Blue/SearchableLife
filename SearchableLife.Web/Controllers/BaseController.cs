using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchableLife.Data.Services;

namespace SearchableLife.Web.Controllers
{
    public abstract class BaseController : Controller
    {

        public ContentService ContentService { get; set; }
        public TagService TagService { get; set; }
        public RouteService RouteService { get; set; }

        public BaseController()
        {
            ContentService = new ContentService();
            TagService = new TagService();
            RouteService = new RouteService();
        }

    }
}

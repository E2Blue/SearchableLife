using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchableLife.Web.Controllers
{
    public class ContentController : BaseController
    {
        public ActionResult Content(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return View("ContentList",ContentService.Search(new Data.Queries.TaggableQuery{PageIndex = 0,PageSize = 10}));
            }

            return View();
        }
    }
}

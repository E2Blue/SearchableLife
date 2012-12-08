using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchableLife.Web.Controllers
{
    public class TagController : BaseController
    {
        public ActionResult Tag(string slug)
        {
            if (!string.IsNullOrEmpty(slug))
            {
                var tag = TagService.GetBySlug(slug);

                if (tag != null)
                {
                    return View(tag);
                }
            }
            return View("index", TagService.Search(new Data.Queries.TagQuery { PageIndex = 0, PageSize = 10 }));
        }

    }
}

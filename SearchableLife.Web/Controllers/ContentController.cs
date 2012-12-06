using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchableLife.Domain.Interface;

namespace SearchableLife.Web.Controllers
{
    public class ContentController : BaseController
    {
        public ActionResult Content(string slug)
        {
            if (!string.IsNullOrEmpty(slug))
            {
                var content = ContentService.Get(slug);

                if (content != null)
                {
                    ViewBag.Tags = TagService.Get(((ITaggable)content).TagNames);
                    return View(content);
                }
            }
            return View("ContentList", ContentService.Search(new Data.Queries.TaggableQuery { PageIndex = 0, PageSize = 10 }));
        }
    }
}

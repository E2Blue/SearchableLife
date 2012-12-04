using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchableLife.Domain.Helpers;
using SearchableLife.Domain.Model;

namespace SearchableLife.Web.Controllers
{
    public class AdminController : BaseController
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Entry(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return View(new Entry());
            }
            return View(ContentService.Get(slug));
        }

        public ActionResult Tag(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return RedirectToAction("Index");
            }

            var result = ContentService.Search(slug);

            return View();
        }

        [HttpPost]
        public ActionResult Entry(Entry entry, string csTags)
        {
            if (!string.IsNullOrEmpty(entry.Title) && !string.IsNullOrEmpty(entry.Slug) && !RouteService.Exists(entry.Slug))
            {
                if (!string.IsNullOrEmpty(csTags))
                {
                    entry.TagNames = StringHelper.csStringTo(csTags);
                }
                ContentService.Update(entry);
            }
            return View();
        }
    }
}

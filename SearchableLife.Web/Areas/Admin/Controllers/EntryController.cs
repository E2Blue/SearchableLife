using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchableLife.Data.Queries;
using SearchableLife.Domain.Model;
using SearchableLife.Web.Areas.Admin.ViewModels;
using SearchableLife.Web.Controllers;
using SearchableLife.Web.Helpers;

namespace SearchableLife.Web.Areas.Admin.Controllers
{
    public class EntryController : BaseController
    {
        //
        // GET: /Admin/Entry/

        public ActionResult Index()
        {

            var result = ContentService.Search<Entry>(new TagQuery() { PageSize = 10, PageIndex = 0 });
            foreach (Entry entry in result)
            {
                entry.HtmlContent = entry.HtmlContent.StripHtml().Ellipsis(200);
            }

            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.Update = false;
            return View("update", new EntryVM{ Model = new Entry() });
        }

        public ActionResult Update(string id)
        {
            var entry = ContentService.Get(id);
            if (entry != null)
            {
                ViewBag.Update = true;
                return View(new EntryVM { Model = (Entry)entry });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(EntryVM entry, string csTags)
        {
            return Create(entry, csTags);
        }

        [HttpPost]
        public ActionResult Create(EntryVM entry, string csTags)
        {
            //Convert the csv string to list of tagnames
            if (!string.IsNullOrEmpty(csTags))
            {
                entry.Model.TagNames = StringHelper.csStringTo(csTags);
            }

            if (!string.IsNullOrEmpty(entry.Model.Title) && !string.IsNullOrEmpty(entry.Model.Slug))
            {
                ContentService.Update(entry.Model);
            }
            return RedirectToAction("Index");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchableLife.Data.Queries;
using SearchableLife.Domain.Helpers;
using SearchableLife.Domain.Model;
using SearchableLife.Web.Controllers;

namespace SearchableLife.Web.Areas.Admin.Controllers
{
    public class EntryController : BaseController
    {
        //
        // GET: /Admin/Entry/

        public ActionResult Index()
        {

            var result = ContentService.Search<Entry>(new TaggableQuery() {PageSize = 10, PageIndex = 0 });

            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.Update = false;
            return View("update",new Entry());
        }

        public ActionResult Update(string id)
        {
            var entry = ContentService.Get(id);
            if(entry != null)
            {
                ViewBag.Update = true;
                return View(entry);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Entry entry, string csTags)
        {
            return Create(entry, csTags);
        }

        [HttpPost]
        public ActionResult Create(Entry entry, string csTags)
        {
            //Convert the csv string to list of tagnames
            if (!string.IsNullOrEmpty(csTags))
            {
                entry.TagNames = StringHelper.csStringTo(csTags);
            }

            if (!string.IsNullOrEmpty(entry.Title) && !string.IsNullOrEmpty(entry.Slug))
            {
                ContentService.Update(entry);
            }
            return RedirectToAction("Index");
        }

    }
}

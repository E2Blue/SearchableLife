using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchableLife.Data.Queries;
using SearchableLife.Domain.Model;
using SearchableLife.Web.Controllers;

namespace SearchableLife.Web.Areas.Admin.Controllers
{
    public class TagController : BaseController
    {
        //
        // GET: /Admin/Tag/

        public ActionResult Index()
        {
            var result = TagService.Search(new TagQuery() { PageIndex = 0, PageSize = 10 });
            return View();
        }

        public ActionResult Create()
        {
            return View("update",new Tag());
        }

        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            TagService.Update(tag);
            return View("index");
        }

    }
}

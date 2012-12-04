using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchableLife.Web.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /Content/

        public ActionResult Content(string id)
        {
            return View();
        }

    }
}

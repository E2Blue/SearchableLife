using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchableLife.Domain.Interface;
using models = SearchableLife.Domain.Model;
using SearchableLife.Web.Helpers;
using SearchableLife.Data.Queries;

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
                    ViewBag.Tags = TagService.Search(new TagQuery { TagNames = ((ITaggable)content).TagNames });
                    return View(content);
                }
            }
            var contents = ContentService.Search(new Data.Queries.TagQuery { PageIndex = 0, PageSize = 10 });
            foreach (models.Content c in contents)
            {
                c.HtmlContent = c.HtmlContent.StripHtml().Ellipsis(500);
            }
            ViewBag.Tags = TagService.Search(new TagQuery { TagNames = contents.SelectMany(c => c.TagNames).GroupBy(s => s).Select(g => g.Key).ToList() });
            return View("ContentList", contents);
        }
    }
}

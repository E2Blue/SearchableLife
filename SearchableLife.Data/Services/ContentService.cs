using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Linq;
using SearchableLife.Data.Indexes;
using SearchableLife.Data.Queries;
using SearchableLife.Domain.Collections;
using SearchableLife.Domain.Interface;
using SearchableLife.Domain.Model;

namespace SearchableLife.Data.Services
{
    /// <summary>
    /// Provides data access to content
    /// </summary>
    public class ContentService : ServiceBase
    {

        TagService _tagService;

        /// <summary>
        /// Deletes a content item
        /// </summary>
        /// <param name="slug">Used to find the item to delete</param>
        public bool Delete(string slug)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var item = session.Query<Content, All_Content>().FirstOrDefault(c => c.Slug.ToLower() == slug.ToLower());
                if (item != null)
                {
                    session.Delete<Content>(item);
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Retrieves a content item, Entry or TagAggregator
        /// </summary>
        /// <param name="slug">The slug used to find the item</param>
        /// <returns></returns>
        public Content Get(string slug)
        {
            slug = slug.ToLower();
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<Content, All_Content>().FirstOrDefault(e => e.Slug == slug);
            }
        }

        /// <summary>
        /// Retrieves content items
        /// </summary>
        /// <param name="tagName">The tag to search for</param>
        /// <returns></returns>
        public PagedList<Content> Search(TagQuery query)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var result = session.Query<Content, All_Taggable>();
                //filter on tag if a tag query is specified
                if (query.TagNames != null && query.TagNames.Count > 0)
                {
                    //FIXME: Currently only filters on the first provided tag name
                    result = (IRavenQueryable<Content>)result.Where(t => t.TagNames.Any(tn => tn == query.TagNames[0]));
                }
                result = (IRavenQueryable<Content>)result.Skip(query.PageSize * query.PageIndex).Take(query.PageSize);

                return new PagedList<Content>(result.ToList()) { PageIndex = query.PageIndex, PageSize = query.PageSize };
            }
        }

        /// <summary>
        /// Strongly typed taggable content search, returns media or entries
        /// </summary>
        /// <typeparam name="taggable">Media or entry</typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagedList<taggable> Search<taggable>(TagQuery query) where taggable : ITaggable
        {
            using (var session = DocumentStore.OpenSession())
            {
                var result = session.Query<taggable, All_Taggable>();
                if (query.TagNames != null && query.TagNames.Count > 0)
                {
                    //FIXME: Currently only filters on the first provided tag name
                    result = (IRavenQueryable<taggable>)result.Where(t => t.TagNames.Any(tn => tn == query.TagNames[0]));
                }
                result = (IRavenQueryable<taggable>)result.Skip(query.PageSize * query.PageIndex).Take(query.PageSize);
                return new PagedList<taggable>(result.ToList()) { PageIndex = query.PageIndex, PageSize = query.PageSize };
            }
        }

        /// <summary>
        /// Updates or creates an content item.
        /// Uses the items slug to check wether to update or create
        /// </summary>
        /// <param name="item">the item to create or update</param>
        public void Update(Content item)
        {
            //It should not be possible to save the item with an integer slug
            int parseableSlug;
            if (int.TryParse(item.Slug, out parseableSlug))
                return;

            //make sure that slugs are always compared in lowercase
            item.Slug = item.Slug.ToLower();

            //the date array should never be possible to overwrite from the ui.
            var dbItem = Get(item.Slug);
            if (dbItem != null)
            {
                item.Updated = dbItem.Updated;
            }

            using (var session = DocumentStore.OpenSession())
            {
                _tagService.CreateNonExisting(item.TagNames, session);

                item.Updated.Add(DateTime.UtcNow);
                session.Store(item, item.Slug);
                session.SaveChanges();
            }
        }

        public ContentService()
        {
            _tagService = new TagService();
        }
    }
}

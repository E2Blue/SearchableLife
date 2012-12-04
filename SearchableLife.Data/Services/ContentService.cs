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
        /// Retrieves a content item, either Tag, Entry or TagAggregator
        /// </summary>
        /// <param name="slug">The slug used to find the item</param>
        /// <returns></returns>
        public IRoutable Get(string slug)
        {
            slug = slug.ToLower();
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<IRoutable, All_Content>().FirstOrDefault(e => e.Slug == slug);
            }
        }

        /// <summary>
        /// Retrieves content items
        /// </summary>
        /// <param name="tagName">The tag to search for</param>
        /// <returns></returns>
        public PagedList<Content> Search(TaggableQuery query)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var result = session.Query<Content, All_Taggable>();
                //filter on tag if a tag query is specified
                if (!string.IsNullOrEmpty(query.TagName))
                {
                    result = (IRavenQueryable<Content>)result.Where(t => t.TagNames.Any(tn => tn == query.TagName));
                }
                result = (IRavenQueryable<Content>)result.Take(query.PageSize).Skip(query.PageSize * query.PageIndex);
                
                return new PagedList<Content>(result.ToList()) { PageIndex = query.PageIndex, PageSize = query.PageSize };
            }
        }

        /// <summary>
        /// Strongly typed taggable content search, returns media or entries
        /// </summary>
        /// <typeparam name="taggable">Media or entry</typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagedList<taggable> Search<taggable>(TaggableQuery query) where taggable : ITaggable
        {
            using (var session = DocumentStore.OpenSession())
            {
                var result = session.Query<taggable>().Where(t => t.TagNames.Any(tn => tn == query.TagName)).Take(query.PageSize).Skip(query.PageSize * query.PageIndex);
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
            //make sure that slugs are always compared in lowercase
            item.Slug = item.Slug.ToLower();

            using (var session = DocumentStore.OpenSession())
            {
                _tagService.CreateNonExisting(item.TagNames,session);

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

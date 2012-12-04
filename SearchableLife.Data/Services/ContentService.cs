﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchableLife.Data.Indexes;
using SearchableLife.Domain.Interface;
using SearchableLife.Domain.Model;

namespace SearchableLife.Data.Services
{
    /// <summary>
    /// Provides data access to content
    /// </summary>
    public class ContentService : ServiceBase
    {
        /// <summary>
        /// Deletes a content item
        /// </summary>
        /// <param name="slug">Used to find the item to delete</param>
        public void Delete(string slug)
        {
            using (var session = DocumentStore.OpenSession())
            {
                //FIXME:should use a slug index
                var item = session.Query<Content>().First(c => c.Slug.ToLower() == slug.ToLower());
                session.Delete<Content>(item);
            }
        }

        /// <summary>
        /// Retrieves a content item, either Tag, Entry or TagAggregator
        /// </summary>
        /// <param name="slug">The slug used to find the item</param>
        /// <returns></returns>
        public Content Get(string slug)
        {
            slug = slug.ToLower();
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<Content,All_Content>().FirstOrDefault(e => e.Slug == slug);
            }
        }

        /// <summary>
        /// Retrieves content items
        /// </summary>
        /// <param name="tagName">The tag to search for</param>
        /// <returns></returns>
        public IEnumerable<ITaggable> Search(string tagName)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var result = session.Query<ITaggable,All_Taggable>().Where(t => t.TagNames.Any(tn => tn == tagName)).ToList();
                return result;
            }
        }

        /// <summary>
        /// Updates or creates an content item.
        /// Uses the items slug to check wether to update or create
        /// </summary>
        /// <param name="item">the item to create or update</param>
        public void Update(Content item)
        {
            item.Slug = item.Slug.ToLower();
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(item, item.Slug);
                session.SaveChanges();
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Raven.Client;
using Raven.Client.Linq;
using SearchableLife.Data.Queries;
using SearchableLife.Domain.Collections;
using SearchableLife.Domain.Model;

namespace SearchableLife.Data.Services
{
    /// <summary>
    /// Service used for creating and getting Tags from the data storage, deletion should not be possible
    /// </summary>
    public class TagService : ServiceBase
    {
        /// <summary>
        /// Returns wether a tag with the specified name exists in the data storage
        /// </summary>
        /// <param name="tagName">The name to search by</param>
        /// <returns>Wether the tag exists</returns>
        public bool Exists(string tagName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tries to retrieve a tag with the specified name
        /// </summary>
        /// <param name="tagName">The name to search by</param>
        /// <returns>The found tag, or null</returns>
        public Tag Get(string tagName)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<Tag>().FirstOrDefault(t => t.Title == tagName);
            }
        }

        public Tag GetBySlug(string slug)
        {
            slug = slug.ToLower();
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<Tag>().FirstOrDefault(t => t.Slug == slug);
            }
        }

        /// <summary>
        /// Returns a set of tags
        /// </summary>
        /// <param name="tagNames">The tagnames to search by</param>
        /// <returns>Found tags</returns>
        public IEnumerable<Tag> Get(List<string> tagNames)
        {
            using (var session = DocumentStore.OpenSession())
            {
                //BLOG: about tags OR mixing
                //var v = "{(Title:tag1) AND (Title:tag2) AND (Title:\"tag 3\") AND (Title:tag\-4) AND (Title:tag\+5)}";
                for(int i = 0;i < tagNames.Count();i++)
                {
                    tagNames[i] = string.Format("(Title:\"{0}\")",tagNames[i]);
                }
                var result = session.Advanced.LuceneQuery<Tag>().Where(string.Join(" OR ",tagNames));
                return result;
            }
        }

        /// <summary>
        /// Updates a tag, creates one if no one with the name exists, name is not updateable
        /// </summary>
        /// <param name="tag"></param>
        public void Update(Tag tag)
        {

        }

        /// <summary>
        /// Creates the tags that doesn't exist
        /// </summary>
        /// <param name="tagNames">Names of the tags that we try to create</param>
        public void CreateNonExisting(List<string> tagNames, IDocumentSession session)
        {
            var tags = session.Query<Tag>();

            foreach(string tagName in tagNames)
            {
                if (!tags.Any(t => t.Title == tagName))
                {
                    session.Store(new Tag { Title = tagName, Slug = HttpUtility.UrlEncode(tagName.Replace(' ','-')) });
                }
            }
        }

        /// <summary>
        /// Search for tags
        /// </summary>
        /// <param name="query">The query object used for getting tags</param>
        /// <returns></returns>
        public PagedList<Tag> Search(GenericQuery query)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var result = session.Query<Tag>().Skip(query.PageSize * query.PageIndex).Take(query.PageSize);
                return new PagedList<Tag>(result.ToList()) { PageIndex = query.PageIndex, PageSize = query.PageSize };
            }
        }
    }
}

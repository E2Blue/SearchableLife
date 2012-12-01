using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a content item
        /// </summary>
        /// <param name="slug">The slug used to find the item</param>
        /// <returns></returns>
        public Content Get(string slug)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves content items
        /// </summary>
        /// <param name="tagName">The tag to search for</param>
        /// <returns></returns>
        public IEnumerable<Content> Search(string tagName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates or creates an content item.
        /// Uses the items slug to check wether to update or create
        /// </summary>
        /// <param name="item">the item to create or update</param>
        public void Update(Content item)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchableLife.Domain.Model;

namespace SearchableLife.Data.Services
{
    /// <summary>
    /// Service used for creating and getting Tags from the data storage, deletion should not be possible
    /// </summary>
    public class TagService: ServiceBase
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a set of tags
        /// </summary>
        /// <param name="tagNames">The tagnames to search by</param>
        /// <returns>Found tags</returns>
        public IEnumerable<Tag> Get(string[] tagNames)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a tag, creates one if no one with the name exists, name is not updateable
        /// </summary>
        /// <param name="tag"></param>
        public void Update(Tag tag)
        {

        }
    }
}

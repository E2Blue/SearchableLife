using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchableLife.Domain.Model;

namespace SearchableLife.Data.Services
{
    /// <summary>
    /// Helps with creating/maintaining routes
    /// </summary>
    public class RouteService : ServiceBase
    {
        /// <summary>
        /// Checks wether a contentitem exists
        /// </summary>
        /// <param name="slug">The slug to check for</param>
        /// <returns>Wether an item exists</returns>
        public bool Exists(string slug)
        {
            slug = slug.ToLower();
            //ugly implementation?
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<Content>().Any(c => c.Slug == slug);
            }
        }
    }
}

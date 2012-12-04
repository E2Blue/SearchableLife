using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;

namespace SearchableLife.Data.Services
{
    public abstract class ServiceBase
    {
        private static readonly Lazy<IDocumentStore> _storage = new Lazy<IDocumentStore>(() =>
        {
            var docStore = new DocumentStore
            {
                ConnectionStringName = "RavenDB"
            };
            docStore.Initialize();

            //OPTIONAL:
            //IndexCreation.CreateIndexes(typeof(Global).Assembly, docStore);

            return docStore;
        });

        public static IDocumentStore DocumentStore
        {
            get { return _storage.Value; }
        }
    }
}

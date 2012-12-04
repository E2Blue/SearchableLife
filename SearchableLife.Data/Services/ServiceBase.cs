using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using SearchableLife.Data.Indexes;

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
            get
            {
                //initialize indexes
                IndexCreation.CreateIndexes(typeof(All_Content).Assembly, _storage.Value);
                IndexCreation.CreateIndexes(typeof(All_Taggable).Assembly, _storage.Value);
                return _storage.Value;
            }
        }
    }
}

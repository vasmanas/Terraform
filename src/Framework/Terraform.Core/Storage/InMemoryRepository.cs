using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Terraform.Core.Storage
{
    public class InMemoryRepository<TModel> : IRepository<TModel>
        where TModel : Entity
    {
        private readonly ConcurrentDictionary<Guid, TModel> storage = new ConcurrentDictionary<Guid, TModel>();

        public TModel Get(Guid id)
        {
            TModel result;

            if (this.storage.TryGetValue(id, out result))
            {
                return result;
            }

            return default(TModel);
        }

        public TModel Get(Func<TModel, bool> filter)
        {
            var values = this.storage.Values.ToList();

            return values.Where(filter).FirstOrDefault();
        }

        public IEnumerable<TModel> List(Func<TModel, bool> filter, int count = 0)
        {
            var values = this.storage.Values.ToList();

            if (count <= 0)
            {
                return values.Where(filter).ToList();
            }
            else
            {
                return values.Where(filter).Take(count).ToList();
            }
        }

        public void Save(TModel model)
        {
            this.storage.AddOrUpdate(model.Key, model, (k, m) => model);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Terraform.Core.Storage
{
    public interface IRepository<TModel>
        where TModel : Entity
    {
        TModel Get(Guid id);

        TModel Get(Func<TModel, bool> filter);

        IEnumerable<TModel> List(Func<TModel, bool> filter, int count = 0);

        void Save(TModel model);
    }
}

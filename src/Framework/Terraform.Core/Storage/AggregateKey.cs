using System;

namespace Terraform.Core.Storage
{
    public class AggregateKey
    {
        public AggregateKey(Guid key)
        {
            this.Key = key;
        }

        public Guid Key { get; private set; }
    }
}

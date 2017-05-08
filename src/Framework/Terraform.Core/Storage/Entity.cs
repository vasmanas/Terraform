using System;

namespace Terraform.Core.Storage
{
    public abstract class Entity
    {
        public Entity()
        {
            this.Key = Guid.NewGuid();
        }

        public Guid Key { get; private set; }
    }
}

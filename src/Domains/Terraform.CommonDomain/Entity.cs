using System;

namespace Terraform.CommonDomain
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

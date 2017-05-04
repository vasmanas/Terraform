using System;
using Terraform.CommonDomain;

namespace Terraform.ResourceDomain
{
    public abstract class Stockpile : Aggregate
    {
        public Stockpile(Resource resource)
        {
            this.Resource = resource ?? throw new ArgumentNullException(nameof(resource));
        }

        public Resource Resource { get; private set; }
    }
}

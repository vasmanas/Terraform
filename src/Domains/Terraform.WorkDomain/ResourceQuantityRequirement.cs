using System;
using Terraform.ResourceDomain;

namespace Terraform.WorkDomain
{
    public class ResourceQuantityRequirement : Requirement
    {
        public ResourceQuantityRequirement(Resource resource, int requiredQuantity)
        {
            this.Resource = resource ?? throw new ArgumentNullException(nameof(resource));

            if (requiredQuantity <= 0)
            {
                throw new ArgumentException("Value must be greater than zero", nameof(requiredQuantity));
            }

            this.RequiredQuantity = requiredQuantity;
            this.StockedQuantity = 0;
        }

        public Resource Resource { get; private set; }

        public int StockedQuantity { get; private set; }

        public int RequiredQuantity { get; private set; }

        public int MissingQuantity
        {
            get
            {
                return this.RequiredQuantity - this.StockedQuantity;
            }
        }

        public int AddResource(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Value must be greater than zero", nameof(quantity));
            }

            if (this.RequiredQuantity == this.StockedQuantity)
            {
                return quantity;
            }

            var neededQuantity = this.RequiredQuantity - this.StockedQuantity;

            if (quantity > neededQuantity)
            {
                quantity = quantity - neededQuantity;

                this.StockedQuantity = this.RequiredQuantity;

                return quantity;
            }

            this.StockedQuantity = this.StockedQuantity + quantity;

            return 0;
        }
    }
}

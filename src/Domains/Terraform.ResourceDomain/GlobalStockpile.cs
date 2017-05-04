using System;

namespace Terraform.ResourceDomain
{
    public class GlobalStockpile : Stockpile
    {
        public GlobalStockpile(Resource resource) : base(resource)
        {
        }

        public int Quantity { get; private set; }

        public void Increase(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Value must be greater than zero", nameof(quantity));
            }

            this.Quantity += quantity;
        }

        public int Reduce(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Value must be greater than zero", nameof(quantity));
            }

            if (this.Quantity > quantity)
            {
                this.Quantity -= quantity;

                return 0;
            }

            quantity -= this.Quantity;

            this.Quantity = 0;

            return quantity;
        }
    }
}

namespace Terraform.CommonDomain
{
    public abstract class Aggregate : Entity
    {
        public AggregateKey GetAggregateKey()
        {
            return new AggregateKey(this.Key);
        }
    }
}

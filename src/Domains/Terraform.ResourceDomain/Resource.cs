using Terraform.CommonDomain;

namespace Terraform.ResourceDomain
{
    public partial class Resource : ValueObject
    {
        public Resource(string displayName)
        {
            this.DisplayName = displayName;
        }

        public string DisplayName { get; private set; }
    }
}

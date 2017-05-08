using Terraform.Core.Storage;

namespace Terraform.LandscapeDomain
{
    public partial class Terrain : ValueObject
    {
        public Terrain(string displayName)
        {
            this.DisplayName = displayName;
        }

        public string DisplayName { get; private set; }
    }
}

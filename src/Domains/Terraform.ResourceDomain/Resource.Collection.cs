namespace Terraform.ResourceDomain
{
    public partial class Resource
    {
        public static class Collection
        {
            public static Resource Wood = new Resource("Wood");

            public static Resource Stone = new Resource("Stone");

            public static Resource Iron = new Resource("Iron");
        }
    }
}

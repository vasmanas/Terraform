namespace Terraform.LandscapeDomain
{
    public partial class Terrain
    {
        public static class Collection
        {
            public static Terrain Space = new Terrain("Space");

            public static Terrain Moutain = new Terrain("Moutain");

            public static Terrain Hill = new Terrain("Hill");

            public static Terrain Flat = new Terrain("Flat");

            public static Terrain Default()
            {
                return Terrain.Collection.Space;
            }
        }
    }
}

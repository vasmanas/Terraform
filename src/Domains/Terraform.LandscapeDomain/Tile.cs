using System;
using System.Collections.Generic;
using Terraform.CommonDomain;

namespace Terraform.LandscapeDomain
{
    public class Tile : Entity
    {
        private readonly List<int> improvements = new List<int>();

        public Tile(Terrain terrain)
        {
            this.Terrain = terrain ?? throw new ArgumentNullException(nameof(terrain));
        }

        public Terrain Terrain { get; private set; }

        // TODO: add different improvements like vegetation, rubble, water, canyon, buildings
        public IReadOnlyCollection<int> Improvements
        {
            get
            {
                return this.improvements.AsReadOnly();
            }
        }

        public void SetTerrain(Terrain terrain)
        {
            this.Terrain = terrain ?? throw new ArgumentNullException(nameof(terrain));
        }
    }
}

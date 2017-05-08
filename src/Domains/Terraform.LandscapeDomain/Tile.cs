using System;
using System.Collections.Generic;
using Terraform.Core.Storage;

namespace Terraform.LandscapeDomain
{
    public class Tile : Entity
    {
        private readonly List<AggregateKey> supplements = new List<AggregateKey>();

        public Tile(Terrain terrain)
        {
            this.Terrain = terrain ?? throw new ArgumentNullException(nameof(terrain));
        }

        public Terrain Terrain { get; private set; }

        // TODO: add different supplements like vegetation, rubble, water, canyon, buildings
        public IReadOnlyCollection<AggregateKey> Supplements
        {
            get
            {
                return this.supplements.AsReadOnly();
            }
        }

        public void SetTerrain(Terrain terrain)
        {
            this.Terrain = terrain ?? throw new ArgumentNullException(nameof(terrain));
        }
    }
}

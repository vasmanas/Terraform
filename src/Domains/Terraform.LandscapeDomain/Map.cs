using System;
using Terraform.Core.Storage;

namespace Terraform.LandscapeDomain
{
    public class Map : Aggregate
    {
        private Tile[,] tiles;

        public Map(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentException("Value must be greater than zero", nameof(width));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Value must be greater than zero", nameof(height));
            }

            this.tiles = new Tile[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    this.tiles[i, j] = new Tile(Terrain.Collection.Default());
                }
            }
        }

        public Tile GetTile(int x, int y)
        {
            return this.tiles[x, y];
        }
    }
}

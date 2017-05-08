using System;
using System.Collections.Generic;
using Terraform.Core.Storage;

namespace Terraform.GameDomain
{
    public class Game : Aggregate
    {
        private readonly List<AggregateKey> stockpiles = new List<AggregateKey>();

        public Game(AggregateKey map)
        {
            this.Map = map ?? throw new ArgumentNullException("map");
        }

        public AggregateKey Map { get; private set; }

        public IReadOnlyCollection<AggregateKey> Stockpiles
        {
            get
            {
                return this.stockpiles.AsReadOnly();
            }
        }

        public void AddStockpile(AggregateKey stockpileKey)
        {
            if (stockpileKey == null)
            {
                throw new ArgumentNullException(nameof(stockpileKey));
            }

            this.stockpiles.Add(stockpileKey);
        }
    }
}

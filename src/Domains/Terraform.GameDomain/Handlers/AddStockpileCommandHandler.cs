using System;
using Terraform.Core.Messaging;
using Terraform.Core.Storage;
using Terraform.ResourceDomain;

namespace Terraform.GameDomain.Handlers
{
    public class AddStockpileCommandHandler : IMessageHandler<AddStockpileCommand>
    {
        private readonly IRepository<Stockpile> stockpileRepository;

        public AddStockpileCommandHandler(IRepository<Stockpile> stockpileRepository)
        {
            this.stockpileRepository = stockpileRepository ?? throw new ArgumentNullException(nameof(stockpileRepository));
        }

        public void Handle(AddStockpileCommand message)
        {
            var resource = message.Resource;
            var game = message.Game;

            // Test for unique storage per resource
            foreach (var stockpileRef in game.Stockpiles)
            {
                var oldStockpile = stockpileRepository.Get(stockpileRef.Key);

                if (resource == oldStockpile.Resource)
                {
                    throw new InvalidOperationException(string.Format("Resource {0} stockpile is pressent", resource.DisplayName));
                }
            }

            var stockpile = new GlobalStockpile(resource);
            stockpileRepository.Save(stockpile);

            game.AddStockpile(stockpile.GetAggregateKey());
        }
    }
}

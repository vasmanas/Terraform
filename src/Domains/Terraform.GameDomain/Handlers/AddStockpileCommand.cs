using System;
using Terraform.Core.Messaging;
using Terraform.ResourceDomain;

namespace Terraform.GameDomain.Handlers
{
    public class AddStockpileCommand : Command
    {
        public AddStockpileCommand(Game game, Resource resource)
        {
            this.Game = game ?? throw new ArgumentNullException(nameof(game));
            this.Resource = resource ?? throw new ArgumentNullException(nameof(resource));
        }

        public Game Game { get; private set; }

        public Resource Resource { get; private set; }
    }
}

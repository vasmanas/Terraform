using Microsoft.VisualStudio.TestTools.UnitTesting;
using Terraform.Core.Dependency;
using Terraform.Core.Logging;
using Terraform.Core.Messaging;
using Terraform.Core.Storage;
using Terraform.GameDomain;
using Terraform.GameDomain.Handlers;
using Terraform.LandscapeDomain;
using Terraform.ResourceDomain;

namespace Terraform.Engine.Tests
{
    [TestClass]
    public class TurnCalculatorTests
    {
        [TestMethod]
        public void Run_Turn_Calculation()
        {
            /// Initialise
            var log = new EmptyLog();
            var locator = new InMemoryLocator();
            locator.AddResolver(typeof(IRepository<Stockpile>), () => new InMemoryRepository<Stockpile>());
            var bus = new InMemoryBus(locator, log);
            Bus.SetBus(bus);
            Bus.RegisterHandler<AddStockpileCommandHandler>();

            /// Start testing
            var calculator = new TurnCalculator();

            var map = new Map(8, 8);
            var game = new Game(map.GetAggregateKey());

            var stockpileRepository = new InMemoryRepository<Stockpile>();

            Bus.Send(new AddStockpileCommand(game, Resource.Collection.Iron));
            Bus.Send(new AddStockpileCommand(game, Resource.Collection.Stone));
            Bus.Send(new AddStockpileCommand(game, Resource.Collection.Wood));

            calculator.Calculate(game);
        }
    }
}

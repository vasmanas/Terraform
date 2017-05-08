using System;
using System.Threading.Tasks;

namespace Terraform.Core.Messaging
{
    /// <summary>
    /// Static bus class.
    /// </summary>
    public static class Bus
    {
        /// <summary>
        /// Message bus.
        /// </summary>
        private static IBus bus;

        /// <summary>
        /// Set bus.
        /// </summary>
        /// <param name="newBus"> Nes bus. </param>
        public static void SetBus(IBus newBus)
        {
            Bus.bus = newBus;
        }

        /// <summary>
        /// Register handler.
        /// </summary>
        /// <typeparam name="THandler"> Message handler type. </typeparam>
        public static Task RegisterHandler<THandler>()
            where THandler : class
        {
            if (Bus.bus == null)
            {
                throw new InvalidOperationException("Message bus not set in static class");
            }

            return Bus.bus.RegisterHandler<THandler>();
        }

        /// <summary>
        /// Unregister handler.
        /// </summary>
        /// <typeparam name="THandler"> Message handler type. </typeparam>
        public static Task UnregisterHandler<THandler>()
            where THandler : class
        {
            if (Bus.bus == null)
            {
                throw new InvalidOperationException("Message bus not set in static class");
            }

            return Bus.bus.UnregisterHandler<THandler>();
        }

        /// <summary>
        /// Send command.
        /// </summary>
        /// <typeparam name="T"> Message type. </typeparam>
        /// <param name="message"> Message message. </param>
        public static Task Send<T>(T message) where T : Message
        {
            if (Bus.bus == null)
            {
                throw new InvalidOperationException("Message bus not set in static class");
            }

            return Bus.bus.Send(message);
        }

        /// <summary>
        /// Query request.
        /// </summary>
        /// <typeparam name="TResponse"> Response type. </typeparam>
        /// <param name="request"> Request. </param>
        /// <returns> Response. </returns>
        public static Task<TResponse> Query<TResponse>(Request<TResponse> request)
        {
            if (Bus.bus == null)
            {
                throw new InvalidOperationException("Message bus not set in static class");
            }

            return Bus.bus.Query(request);
        }
    }

}

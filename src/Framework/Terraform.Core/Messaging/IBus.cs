using System.Threading.Tasks;

namespace Terraform.Core.Messaging
{
    /// <summary>
    /// Bus interface.
    /// </summary>
    public interface IBus
    {
        /// <summary>
        /// Register handler.
        /// </summary>
        /// <typeparam name="THandler"> Message hadler type. </typeparam>
        Task RegisterHandler<THandler>()
            where THandler : class;

        /// <summary>
        /// Unregister handler.
        /// </summary>
        /// <typeparam name="THandler"> Message hadler type. </typeparam>
        Task UnregisterHandler<THandler>()
            where THandler : class;
        
        /// <summary>
        /// Send command.
        /// </summary>
        /// <typeparam name="TMessage"> Message type. </typeparam>
        /// <param name="message"> Message message. </param>
        Task Send<TMessage>(TMessage message)
            where TMessage : class;

        /// <summary>
        /// Query request.
        /// </summary>
        /// <typeparam name="TResponse"> Response type. </typeparam>
        /// <param name="request"> Request. </param>
        /// <returns> Response. </returns>
        Task<TResponse> Query<TResponse>(Request<TResponse> request);
    }
}

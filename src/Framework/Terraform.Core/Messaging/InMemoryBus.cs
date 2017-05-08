using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terraform.Core.Dependency;
using Terraform.Core.Logging;

namespace Terraform.Core.Messaging
{
    /// <summary>
    /// In memory bus.
    /// </summary>
    public class InMemoryBus : IBus
    {
        /// <summary>
        /// Registered message handlers.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, List<Type>> MessageHandlers =
            new ConcurrentDictionary<Type, List<Type>>();

        private readonly IServiceLocator resolver;
        private readonly ILog log;

        public InMemoryBus(IServiceLocator resolver, ILog log)
        {
            this.resolver = resolver;
            this.log = log;
        }

        /// <summary>
        /// Register handler.
        /// </summary>
        /// <typeparam name="THandler"> Message hadler type. </typeparam>
        public Task RegisterHandler<THandler>()
            where THandler : class
        {
            return Task.Run(() => this.InternalRegisterHandler<THandler>());
        }

        /// <summary>
        /// Unregister handler.
        /// </summary>
        /// <typeparam name="THandler"> Message hadler type. </typeparam>
        public Task UnregisterHandler<THandler>()
            where THandler : class
        {
            return Task.Run(() => this.InternalUnregisterHandler<THandler>());
        }

        /// <summary>
        /// Send command.
        /// </summary>
        /// <typeparam name="TMessage"> Message type. </typeparam>
        /// <param name="message"> Message message. </param>
        public Task Send<TMessage>(TMessage message)
            where TMessage : class
        {
            return Task.Run(() => this.InternalSend(message));
        }

        public Task<TResponse> Query<TResponse>(Request<TResponse> request)
        {
            return Task<TResponse>.Run<TResponse>(() => this.InternalQuery(request));
        }

        private void InternalRegisterHandler<THandler>()
            where THandler : class
        {
            var handlerType = typeof(THandler);

            if (handlerType.IsInterface)
            {
                return;
            }

            foreach (var i in handlerType.GetInterfaces())
            {
                if (!i.IsGenericType)
                {
                    continue;
                }
                
                if (i.GetGenericTypeDefinition() == typeof(IMessageHandler<>))
                {
                    var messageTypes = i.GetGenericArguments();

                    if (messageTypes.Length != 1)
                    {
                        continue;
                    }

                    var messageType = messageTypes[0];

                    if (!messageType.IsSubclassOf(typeof(Message)))
                    {
                        continue;
                    }

                    var handlers = InMemoryBus.MessageHandlers.GetOrAdd(messageType, type => new List<Type>());

                    if (!handlers.Contains(handlerType))
                    {
                        handlers.Add(handlerType);
                    }
                }
                else if (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                {
                    var requestTypes = i.GetGenericArguments();

                    if (requestTypes.Length != 2)
                    {
                        continue;
                    }

                    var requestType = requestTypes[0];

                    if (!typeof(Request<>).IsSubclassOfRawGeneric(requestType))
                    {
                        continue;
                    }

                    var handlers = InMemoryBus.MessageHandlers.GetOrAdd(requestType, type => new List<Type>());

                    if (!handlers.Contains(handlerType))
                    {
                        handlers.Add(handlerType);
                    }
                }
            }
        }

        private void InternalUnregisterHandler<THandler>()
            where THandler : class
        {
            var handlerType = typeof(THandler);

            if (handlerType.IsInterface)
            {
                return;
            }

            foreach (var i in handlerType.GetInterfaces())
            {
                if (!i.IsGenericType)
                {
                    continue;
                }

                if (i.GetGenericTypeDefinition() == typeof(IMessageHandler<>))
                {
                    var messageTypes = i.GetGenericArguments();

                    if (messageTypes.Length != 1)
                    {
                        continue;
                    }

                    var messageType = messageTypes[0];

                    if (!messageType.IsSubclassOf(typeof(Message)))
                    {
                        continue;
                    }

                    List<Type> handlers;
                    InMemoryBus.MessageHandlers.TryGetValue(messageType, out handlers);

                    handlers.Remove(handlerType);
                }
                else if (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                {
                    var requestTypes = i.GetGenericArguments();

                    if (requestTypes.Length != 1)
                    {
                        continue;
                    }

                    var requestType = requestTypes[0];

                    if (!typeof(Request<>).IsSubclassOfRawGeneric(requestType))
                    {
                        continue;
                    }

                    List<Type> handlers;
                    InMemoryBus.MessageHandlers.TryGetValue(requestType, out handlers);

                    handlers.Remove(handlerType);
                }
            }
        }

        private void InternalSend<TMessage>(TMessage message)
            where TMessage : class
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            var messageType = typeof(TMessage);

            List<Type> handlers;
            if (!InMemoryBus.MessageHandlers.TryGetValue(messageType, out handlers))
            {
                return;
            }
            
            foreach (var handlerType in handlers)
            {
                if (!handlerType.GetInterfaces().Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IMessageHandler<>)))
                {
                    continue;
                }

                dynamic handler = this.resolver.GetService(handlerType);
                
                try
                {
                    handler.Handle((dynamic)message);
                }
                catch (Exception ex)
                {
                    this.log.ErrorFormat(ex.ToString());
                }
            }
        }

        private TResponse InternalQuery<TResponse>(Request<TResponse> request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var requestType = request.GetType();

            List<Type> handlers;
            if (!InMemoryBus.MessageHandlers.TryGetValue(requestType, out handlers))
            {
                return default(TResponse);
            }
            
            foreach (var handlerType in handlers)
            {
                if (!handlerType.GetInterfaces().Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                {
                    continue;
                }

                dynamic handler = this.resolver.GetService(handlerType);

                try
                {
                    var result = handler.Handle((dynamic)request);

                    return (TResponse)result;
                }
                catch (Exception ex)
                {
                    this.log.ErrorFormat(ex.ToString());
                }
            }

            return default(TResponse);
        }
    }
}

using System;
using System.Collections.Concurrent;

namespace Terraform.Core.Dependency
{
    public class InMemoryLocator : IServiceLocator
    {
        private readonly ConcurrentDictionary<Type, Func<object>> factories = new ConcurrentDictionary<Type, Func<object>>();

        public object GetService(Type type)
        {
            if (this.factories.TryGetValue(type, out Func<object> factory))
            {
                return factory();
            }

            throw new InvalidOperationException(string.Format("Type {0} has no registered factory", type.Name));
        }

        public void AddResolver(Type type, Func<object> factory)
        {
            this.factories.AddOrUpdate(type, factory, (t, f) => factory);
        }
    }
}

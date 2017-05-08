using System;

namespace Terraform.Core.Logging
{
    public static partial class Log
    {
        public static class Factory
        {
            private static Func<Type, ILog> producer;

            public static void SetProducer(Func<Type, ILog> producer)
            {
                Factory.producer = producer;
            }

            public static ILog Create<T>()
            {
                return Factory.Create(typeof(T));
            }

            public static ILog Create(Type type)
            {
                return Factory.producer(type);
            }
        }
    }
}

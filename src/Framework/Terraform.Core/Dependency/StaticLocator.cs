using System;

namespace Terraform.Core.Dependency
{
    public static class StaticLocator<T> where T : class
    {
        private static T obj = null;

        public static T UseOrCreate(Func<T> factory)
        {
            if (obj == null)
            {
                obj = factory();
            }

            return obj;
        }
    }
}

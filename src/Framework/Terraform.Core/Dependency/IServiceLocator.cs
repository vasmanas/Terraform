using System;

namespace Terraform.Core.Dependency
{
    public interface IServiceLocator
    {
        object GetService(Type type);
    }
}

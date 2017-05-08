namespace Terraform.Core.Dependency
{
    public static class ServiceLocatorExtensions
    {
        public static TModel GetService<TModel>(this IServiceLocator locator)
        {
            var type = typeof(TModel);

            return (TModel)locator.GetService(type);
        }
    }
}

using BLL.Abstractions.Services;
using BLL.Concretions.Services;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace BLL
{
    public class BLLPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IProductService, ProductService>();

            container.Register<ISignInService, SignInService>();
        }
    }
}
using DAL.Abstractions.Helpers;
using DAL.Abstractions.Repositories;
using DAL.Concretions.Helpers;
using DAL.Concretions.Repositories;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace DAL
{
    public class DALPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICurrentContext, CurrentContext>(Lifestyle.Scoped);

            container.Register<IProductRepository, ProductRepository>();

            container.Register<IUserRepository, UserRepository>();
        }
    }
}
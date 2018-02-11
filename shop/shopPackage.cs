using AutoMapper;
using SimpleInjector;
using SimpleInjector.Packaging;
using System.Collections.Generic;
using System.Reflection;

namespace shop
{
    public class ShopPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterMapperProfiles(container);
        }

        private static void RegisterMapperProfiles(Container container)
        {
            container.RegisterCollection<Profile>(GetAssembliesContainingMapperProfiles());

            container.RegisterSingleton(() =>
            {
                var profiles = container.GetAllInstances<Profile>();

                var config = new MapperConfiguration(cfg =>
                {
                    foreach (var profile in profiles)
                    {
                        cfg.AddProfile(profile);
                    }
                });

                return config;
            });

            container.Register(() =>
            {
                var config = container.GetInstance<MapperConfiguration>();

                return config.CreateMapper(container.GetInstance);
            });
        }

        private static IEnumerable<Assembly> GetAssembliesContainingMapperProfiles()
        {
            return new[] { typeof(ShopPackage).Assembly, typeof(BLL.BLLPackage).Assembly };
        }
    }
}
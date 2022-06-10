using Autofac;
using NLayer.Repository;
using NLayer.Service.Mapping;
using System.Reflection;
using Module = Autofac.Module; //Önemliiii
namespace NLayer.Api.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var apiAssembly=Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(
                x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            //InstancePerLifetimeScope => Scope
            //InstancePerDependency => Transient

        }
    }
}

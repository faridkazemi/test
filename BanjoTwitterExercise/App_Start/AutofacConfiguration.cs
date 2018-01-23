using Autofac;
using Autofac.Integration.Mvc;
using BanjoTwitterExercise.Helpers;
using BanjoTwitterExercise.Repository;
using System.Reflection;
using System.Web.Mvc;

namespace BanjoTwitterExercise.App_Start
{
    public class AutofacConfiguration
    {
        public static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //Registering Repositories
            builder.RegisterAssemblyTypes(typeof(TweetRepository).Assembly)
                .Where(ty => ty.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<HttpRequestHeader>().As<IHttpRequestHeader>().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
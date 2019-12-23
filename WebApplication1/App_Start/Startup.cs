using System;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Owin;
using RecrutmentAgency;
using RecrutmentAgency.Controllers;
using RecrutmentAgency.Data;
using RecrutmentAgency.Data.Filters;
using RecrutmentAgency.Data.Repositories;
using RecrutmentAgency.Files;

[assembly: OwinStartup(typeof(Startup))]
namespace RecrutmentAgency
{
    public partial class Startup
    {
        public static void Configuration(IAppBuilder app)
        { 
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(PhotoFileWrapper), new PhotoFileModelBinder());

            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"];
            if (connectionString == null)
            {
                throw new Exception("Не найдена строка подключения");
            }

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(x => { 
                var cfg = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString(connectionString.ConnectionString)
                        .Dialect<MsSql2012Dialect>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Candidate>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Vacancy>())
                    .CurrentSessionContext("call");
                    var conf = cfg.BuildConfiguration();
                    var schemeExport = new SchemaUpdate(conf);
                    schemeExport.Execute(false, true);
                return cfg.BuildSessionFactory();
            }).As<ISessionFactory>().SingleInstance();
            containerBuilder
                .Register(x => x.Resolve<ISessionFactory>().OpenSession())
                .As<ISession>()
                .InstancePerRequest();
            containerBuilder.RegisterControllers(Assembly.GetAssembly(typeof(HomeController)))
                .PropertiesAutowired();
            containerBuilder.RegisterModule(new AutofacWebTypesModule());
            containerBuilder.RegisterType<UserRepository>()
                .AsSelf()
                .As<Repository<User, UserFilter>>();
            containerBuilder.RegisterType<CandidateRepository>()
                .AsSelf()
                .As<Repository<Candidate, CandidateFilter>>();
            containerBuilder.RegisterType<VacancyRepository>()
                .AsSelf()
                .As<Repository<Vacancy, VacancyFilter>>();
            containerBuilder.RegisterType<FileRepository>();
            containerBuilder.RegisterType<PhotoFileContentRepository>();
            containerBuilder.RegisterType<DbFileProvider>().As<IFileProvider>();
            containerBuilder.RegisterType<LocalFileProvider>().As<IFileProvider>();
            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);

            app.CreatePerOwinContext(() =>
                new UserManager(new IdentityStore(DependencyResolver.Current.GetService<ISession>())));
            app.CreatePerOwinContext<SignInManager>((opt, context) => 
                new SignInManager(context.GetUserManager<UserManager>(), context.Authentication));
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider()
            });
        }
    }
}
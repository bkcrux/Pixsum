using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using AutoMapper;
using Pixsum.API.Mappings;
using Pixsum.API.Models;
using Pixsum.Data;
using Pixsum.Data.Interfaces;
using Pixsum.Entities;
using Pixsum.Logic;
using Pixsum.Logic.Interfaces;
using Pixsum.Services;
using Pixsum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Pixsum.API
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Data
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            // Repository generic
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerRequest();

            //Logic classes
            builder.RegisterType<AccountLogic<Account>>().As<IAccountLogic<Account>>().InstancePerRequest();
            //TODO - hook up remaining logic classes

            // Services
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerRequest();
            //TODO - hook up remaining services

            //Automapper
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToAPIModelMappingProfile>();
                cfg.AddProfile<APIModelToDomainMappingProfile>();
            })).AsSelf().SingleInstance();
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();
            builder.RegisterType<MappingEngine>().As<IMappingEngine>();


            Container = builder.Build();

            return Container;
        }
    }
}
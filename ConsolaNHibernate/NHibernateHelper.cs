using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate
{
   
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Tool.hbm2ddl;
    using ConsolaNHibernate.Mapeoak;

    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(
                    MySQLConfiguration.Standard
                        .ConnectionString(cs => cs
                            .Server("localhost")
                            .Database("entrega2")
                            .Username("root")
                            .Password("1MG32025")
                        )
                )
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<ErabiltzaileaMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true)) // DROP and CREATE egiten du
                //.ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)) // Soilik existitzen ez bada sortzen du
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}


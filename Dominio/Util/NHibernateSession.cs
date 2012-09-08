﻿using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;

namespace Dominio.Util
{
    public class NHibernateSession
    {
        private static ISessionFactory _sessionFactory;

        public static ISession OpenSession()
        {
            if (_sessionFactory == null)
            {
                var mapper = new ModelMapper();
                mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
                var map = mapper.CompileMappingForAllExplicitlyAddedEntities();

                var configurantion = new Configuration();
                configurantion.DataBaseIntegration(conf => {
                    conf.Dialect<MsSql2012Dialect>();
                    conf.ConnectionString = "Data Source=(local);Initial Catalog=ESTUDONH;Integrated Security=False;User ID=sa;Password=;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                    conf.Driver<Sql2008ClientDriver>();
                });

                configurantion.AddMapping(map);
                _sessionFactory = configurantion.BuildSessionFactory();
            }

            return _sessionFactory.OpenSession();
        }

        public static void CloseSession() {
            _sessionFactory.Close();

        }
    }
}

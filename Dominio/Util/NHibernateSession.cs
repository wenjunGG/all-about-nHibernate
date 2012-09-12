using NHibernate;
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
                    conf.Dialect<SQLiteDialect>();
                    conf.ConnectionString = "Data Source=data-domain.db;Version=3";
                    conf.Driver<SQLiteDriver>();
                    conf.LogFormattedSql = true;
                    conf.LogSqlInConsole = true;
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

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;

namespace Dominio.Simples.Util
{
    public class NHibernateSession
    {
        private static ISessionFactory _sessionFactory;

        public static ISession OpenSession() {

            if (_sessionFactory == null)
            {
                var mapper = new ModelMapper();
                mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
                var map = mapper.CompileMappingForAllExplicitlyAddedEntities();

                var config = new Configuration();
                config.DataBaseIntegration(conf => {
                    conf.Dialect<SQLiteDialect>();
                    conf.ConnectionString = "Data Source=data-simple-domain.db;Version=3";
                    conf.Driver<SQLite20Driver>();
                    conf.LogFormattedSql = false;
                    conf.LogSqlInConsole = false;
                });

                config.AddMapping(map);
                _sessionFactory = config.BuildSessionFactory();
            }



            return _sessionFactory.OpenSession();
        }
        public static void Close() { _sessionFactory.Close(); }
    }
}

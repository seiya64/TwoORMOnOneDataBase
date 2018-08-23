using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHproject.Entities;

namespace NHproject
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var _sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString("Server=(localdb)\\MSSQLLocalDB;database=twoormonedb;Integrated Security=SSPI;"))
                    .Mappings(m => m
                    .FluentMappings.AddFromAssemblyOf<MyObject>())
                    .BuildSessionFactory();
            return _sessionFactory.OpenSession();
        }
    }
}

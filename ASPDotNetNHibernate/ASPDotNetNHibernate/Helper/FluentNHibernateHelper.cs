using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using ISession = NHibernate.ISession;
using NHibernate.Tool.hbm2ddl;

namespace ASPDotNetNHibernate.Helper
{
    public static class FluentNHibernateHelper<T>
    {
        public static ISession OpenSession()
        {
            string connectionString = "Server=localhost;Port=3306;Database=student_management;Uid=root;Pwd=123456";

            ISessionFactory sessionFactory = Fluently.Configure()

                .Database(MySQLConfiguration.Standard

                  .ConnectionString(connectionString).ShowSql()

                )

                .Mappings(m =>

                          m.FluentMappings

                              .AddFromAssemblyOf<T>())

                .ExposeConfiguration(cfg => new SchemaExport(cfg)

                 .Create(false, false))

                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}

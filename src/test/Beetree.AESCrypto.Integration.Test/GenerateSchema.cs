using Beetree.AESCrypto.Business.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Beetree.AESCrypto.Business.Integration.Test
{
    [TestFixture]
    public class GenerateSchema
    {
        [Test]
        public void Can_generate_schema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(PaymentAttempt).Assembly);

            new SchemaExport(cfg).Execute(false, true, false);
        }
    }
}

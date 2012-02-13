using Beetree.AESCrypto.Business.Domain;
using Beetree.AESCrypto.Business.Repositories;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Beetree.AESCrypto.Business.Integration.Test
{
    [TestFixture]
    public class PaymentRepository_Fixture
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        private readonly PaymentAttempt[] _paymentAttempts = new[]
                 {
                     new PaymentAttempt { FirstName = "Joe", AccountNumber = "12345678", 
                        Amount = 11.0m, LastName = "Bloggs", SortCode="102033"},
                     new PaymentAttempt { FirstName = "Joe", AccountNumber = "11112222", 
                        Amount = 102.0m, LastName = "Bloggs", SortCode="102033"},
                        new PaymentAttempt { FirstName = "Joe", AccountNumber = "22223333", 
                        Amount = 130.0m, LastName = "Bloggs", SortCode="102033"},
                        new PaymentAttempt { FirstName = "Desperate", AccountNumber = "33334444", 
                        Amount = 104.0m, LastName = "Dan", SortCode="102033"},
                        new PaymentAttempt { FirstName = "Nigel", AccountNumber = "09876542", 
                        Amount = 105.0m, LastName = "Taylor", SortCode="102033"},
                        new PaymentAttempt { FirstName = "Joachim", AccountNumber = "99199199", 
                        Amount = 610.0m, LastName = "Smith", SortCode="102033"}
                 };

        private void CreateInitialData()
        {

            using (ISession session = _sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                foreach (var product in _paymentAttempts)
                    session.Save(product);
                transaction.Commit();
            }
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(PaymentAttempt).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        [SetUp]
        public void SetupContext()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
            CreateInitialData();
        }

        [Test]
        public void Can_add_new_product()
        {
            var product = new PaymentAttempt { FirstName = "Joe", AccountNumber = "12345678", 
                Amount = 10.0m, LastName = "Bloggs", SortCode="102033"};
            IPaymentAttemptRepository repository = new PaymentAttemptRepository();
            repository.Add(product);
        }

        [Test]
        public void Can_get_existing_product_by_id()
        {
            IPaymentAttemptRepository repository = new PaymentAttemptRepository();
            var fromDb = repository.GetById(_paymentAttempts[1].Id);
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(_paymentAttempts[1], fromDb);
            Assert.AreEqual(_paymentAttempts[1].AccountNumber, fromDb.AccountNumber);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using NHibernate;
using NHibernate.Cfg;
using Beetree.AESCrypto.Business.Domain;
using Beetree.AESCrypto.Business.Repositories;
using NHibernate.Tool.hbm2ddl;

namespace Beetree.AESCrypto.Integration.Test
{
    [TestFixture]
    public class SimpleEASTest
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

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
        }

        [Test]
        public void DecryptUsingFileKeys_KnownDecryptedString_ReturnsKnownString()
        {
            // write a new record
            var product = new PaymentAttempt
            {
                FirstName = "Joe",
                AccountNumber = "12345678",
                Amount = 10.0m,
                LastName = "Bloggs",
                SortCode = "102033"
            };
            IPaymentAttemptRepository repository = new PaymentAttemptRepository();
            repository.Add(product);

            // get the record


            // assert the values match for input/output
            
        }
    }
}

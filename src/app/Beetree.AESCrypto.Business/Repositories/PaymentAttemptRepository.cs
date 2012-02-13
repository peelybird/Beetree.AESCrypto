using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beetree.AESCrypto.Business.Domain;
using NHibernate;
using FirstSolution.Repositories;
using NHibernate.Criterion;

namespace Beetree.AESCrypto.Business.Repositories
{
    public class PaymentAttemptRepository : IPaymentAttemptRepository
    {
        public void Add(PaymentAttempt paymentAttempt)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(paymentAttempt);
                    transaction.Commit();
                }
            }
        }

        public void Update(PaymentAttempt paymentAttempt)
        {
            throw new NotImplementedException();
        }

        public void Remove(PaymentAttempt paymentAttempt)
        {
            throw new NotImplementedException();
        }

        public PaymentAttempt GetById(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<PaymentAttempt>(id);
            }
        }
    }
}

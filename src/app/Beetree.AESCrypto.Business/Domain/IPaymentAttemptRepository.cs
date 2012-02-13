using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beetree.AESCrypto.Business.Domain
{
    public interface IPaymentAttemptRepository
    {
        void Add(PaymentAttempt paymentAttempt);
        void Update(PaymentAttempt paymentAttempt);
        void Remove(PaymentAttempt paymentAttempt);
        PaymentAttempt GetById(Guid id);
    }
}

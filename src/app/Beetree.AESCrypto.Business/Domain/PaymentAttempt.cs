using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beetree.AESCrypto.Business.Domain
{
    public class PaymentAttempt
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string SortCode { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual decimal Amount { get; set; }
    }
}

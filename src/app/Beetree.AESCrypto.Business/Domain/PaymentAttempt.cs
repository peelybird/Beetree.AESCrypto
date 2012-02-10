using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beetree.AESCrypto.Business.Domain
{
    public class PaymentAttempt
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}

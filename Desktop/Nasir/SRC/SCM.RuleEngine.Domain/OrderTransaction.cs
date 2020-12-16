using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.RuleEngine.Domain
{
   public class  PaymentResponse
    {
        public string TransactionId { get; set; }
        public string OrderId { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionType { get; set; }

    }
}


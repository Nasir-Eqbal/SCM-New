using System;

namespace SCM.RuleEngine.Domain
{
    public class Receipt
    {
        public Receipt()
        {
        }

        public string ReceiptId { get; set; }
        public string OrderId { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
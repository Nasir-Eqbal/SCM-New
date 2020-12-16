using System;
using System.Collections.Generic;

namespace SCM.RuleEngine.Domain
{
    public class Order
    {
        public Order()
        {
        }
        public string OrderId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public List<Product>  ProductSelected { get; set; }
        public string OrderStatus { get; set; }
    }
}
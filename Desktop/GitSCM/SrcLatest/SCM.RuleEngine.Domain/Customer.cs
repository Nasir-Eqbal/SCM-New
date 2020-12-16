namespace SCM.RuleEngine.Domain
{
    public class Customer
    {
        public string  CustomerId { get; set; }
        public string OrderId { get; set; }
        public string EmailId { get; set; }
        public bool IsNewCustomer { get; set; }
        public ShippingAddress Address { get; set; }
    }
}
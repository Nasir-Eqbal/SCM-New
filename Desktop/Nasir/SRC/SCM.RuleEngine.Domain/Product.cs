namespace SCM.RuleEngine.Domain
{
    public class Product
    {
        public Product()
        {
        }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public float ProductPrice { get; set; }
        public ProductTypes ProducType { get; set; }
        public int Quantity { get; set; }
    }
}
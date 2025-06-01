namespace ALSiteBack.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<ProductCart> ProductCarts { get; set; }
    }
}

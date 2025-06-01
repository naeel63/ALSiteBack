namespace ALSiteBack.Models
{
    public class ProductCart
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public int ProductQuantity { get; set; }
        
    }
}

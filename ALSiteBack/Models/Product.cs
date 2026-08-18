namespace ALSiteBack.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Ostatok { get; set; }
        public int Price { get; set; }
        public Group Group { get; set; }
    }
}
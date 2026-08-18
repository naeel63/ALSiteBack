namespace ALSiteBack.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }

        public bool PersonalDataConsent { get; set; }

        public int Total { get; set; }
        public string Currency { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<OrderItem> Items { get; set; }
    }
}
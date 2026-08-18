namespace ALSiteBack.Dto
{
    public class OrderDto
    {
        public CustomerDto Customer { get; set; }
        public List<OrderItemDto> Items { get; set; }

        public int Total { get; set; }
        public string Currency { get; set; }
    }

    public class CustomerDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }
        public bool PersonalDataConsent { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
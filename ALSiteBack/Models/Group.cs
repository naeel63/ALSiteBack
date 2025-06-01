namespace ALSiteBack.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Group? Parent { get; set; }
        public ICollection<Group>? Children { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}

namespace ALSiteBack.Dto
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GroupDto> Children { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}

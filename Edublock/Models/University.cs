namespace Edublock.Models
{
    public class University : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ThumbnailUrl { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}

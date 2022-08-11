namespace Edublock.Models
{
    public class University
    {
        public int UniversityId { get; set; }
        public string UniversityName { get; set; } = string.Empty;
        public string? UniversityDescription { get; set; }
        public string? ThumbnailUrl { get; set; }
        public ICollection<Department>? Departments { get; set; }
    }
}

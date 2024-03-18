namespace VirtualSchool.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Level { get; set; }
        public Teacher? Teacher { get; set; }
        public ICollection<ApplicationUser>? Students { get; set; }

    }
}

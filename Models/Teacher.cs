namespace VirtualSchool.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Grade { get; set; }
        public ICollection<Course>? Courses { get;}
    }
}

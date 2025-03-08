namespace UniversitySys.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manager { get; set; }

        public List<Instructor>? Instructor { get; set; }
        public List<Course>? Course { get; set; }
        public List<Trainee>? Trainee { get; set; }

    }
}

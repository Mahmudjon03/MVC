namespace WebTestProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string? ses { get; set; }
        public List<Works> Works { get; set; }
        public bool test { get; set; }
    }
}

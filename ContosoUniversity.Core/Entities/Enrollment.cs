namespace ContosoUniversity.Entities
{
    public class Enrollment : Entity
    {
        public Grade? Grade { get; set; }

        public Course Course { get; set; } = null!; 
        public Student Student { get; set; } = null!;
    }
}

namespace ContosoUniversity.Entities
{
    public class Course : Entity
    {
        public string Title { get; set; } = null!;
        public int Credits { get; set; }

        readonly List<Enrollment> _enrollments = new List<Enrollment>();
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();
    }
}

using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Entities
{
    public class Student : Entity
    {
        public string LastName { get; set; } = null!;

        public string FirstMidName { get; set; } = null!;
        public DateTime EnrollmentDate { get; set; }

        readonly List<Enrollment> _enrollments = new List<Enrollment>();
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();
        //public byte[]? Photo { get; set; }
    }
}

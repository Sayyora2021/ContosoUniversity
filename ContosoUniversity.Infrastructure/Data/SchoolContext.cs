using ContosoUniversity.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<Student> Students => Set<Student>();

        public SchoolContext(DbContextOptions<SchoolContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(b => b.LastName)
                .IsRequired()
                .HasMaxLength(32);
            
            modelBuilder.Entity<Student>()
                .Property(b => b.FirstMidName)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Course>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   Id = 1, 
                   FirstMidName = "Carson",
                   LastName = "Alexander",
                   EnrollmentDate = DateTime.Parse("2010-09-01")
               },
                new Student
                {
                    Id = 2,
                    FirstMidName = "Meredith",
                    LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new Student
                {
                    Id = 3,
                    FirstMidName = "Arturo",
                    LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01")
                },
                new Student
                {
                    Id = 4,
                    FirstMidName = "Gytis",
                    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new Student
                {
                    Id = 5,
                    FirstMidName = "Yan",
                    LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new Student
                {
                    Id = 6,
                    FirstMidName = "Peggy",
                    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01")
                },
                new Student
                {
                    Id = 7,
                    FirstMidName = "Laura",
                    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01")
                },
                new Student
                {
                    Id = 8,
                    FirstMidName = "Nino",
                    LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-09-01")
                });

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Chemistry", Credits = 3 },
                new Course { Id = 2, Title = "Microeconomics", Credits = 3 },
                new Course { Id = 3, Title = "Macroeconomics", Credits = 3 },
                new Course { Id = 4, Title = "Calculus", Credits = 4 },
                new Course { Id = 5, Title = "Trigonometry", Credits = 4 },
                new Course { Id = 6, Title = "Composition", Credits = 3 },
                new Course { Id = 7, Title = "Literature", Credits = 4 }
                );

            modelBuilder.Entity<Enrollment>().HasData(
                new 
                {
                    Id = 1,
                    StudentId = 1,
                    CourseId = 1,
                    Grade = Grade.A
                },
                new 
                {
                    Id = 2,
                    StudentId = 1,
                    CourseId = 2,
                    Grade = Grade.C
                },
                new 
                {
                    Id = 3,
                    StudentId = 1,
                    CourseId = 3,
                    Grade = Grade.B
                },
                new 
                {
                    Id = 4,
                    StudentId = 2,
                    CourseId = 4,
                    Grade = Grade.B
                },
                new 
                {
                    Id = 5,
                    StudentId = 2,
                    CourseId = 5,
                    Grade = Grade.B
                },
                new 
                {
                    Id = 6,
                    StudentId = 2,
                    CourseId = 6,
                    Grade = Grade.B
                },
                new 
                {
                    Id = 7,
                    StudentId = 3,
                    CourseId = 1
                },
                new 
                {
                    Id = 8,
                    StudentId = 3,
                    CourseId = 2,
                    Grade = Grade.B
                },
                new 
                {
                    Id = 9,
                    StudentId = 4,
                    CourseId = 1,
                    Grade = Grade.B
                },
                new 
                {
                    Id = 10,
                    StudentId = 5,
                    CourseId = 6,
                    Grade = Grade.B
                },
                new 
                {
                    Id =11,
                    StudentId = 6,
                    CourseId = 7,
                    Grade = Grade.B
                }
            );
        }
    }
}
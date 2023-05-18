using ContosoUniversity.Entities;
using ContosoUniversity.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Data
{
    public class StudentsRepository : IStudentRepository
    {
        SchoolContext Context { get; }

        public StudentsRepository(SchoolContext context)
        {
            Context = context;
        }

        public async Task Delete(Student student)
        {
            Context.Students.Remove(student);
            await Context.SaveChangesAsync();
        }

        public async Task<Student?> GetById(int id)
        {
            return await Context.Students.FindAsync(id);
        }

        public async Task<Student> Insert(Student student)
        {
            Context.Add(student);
            await Context.SaveChangesAsync();
            return student;
        }


        public async Task<IEnumerable<Student>> ListAll()
        {
            return await Context.Students.ToListAsync();
        }

        public async Task Update(Student student)
        {
            Context.Update(student);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> DoesExist(int id)
        {
            if (await Context.Students.FindAsync(id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
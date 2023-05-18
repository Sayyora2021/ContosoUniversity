using ContosoUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Seedwork
{
    public interface IStudentRepository
    {
        Task Delete(Student student);
        Task<bool> DoesExist(int id);
        Task<Student?> GetById(int id);
        Task<Student> Insert(Student student);
        Task<IEnumerable<Student>> ListAll();
        Task Update(Student student);
    }
}


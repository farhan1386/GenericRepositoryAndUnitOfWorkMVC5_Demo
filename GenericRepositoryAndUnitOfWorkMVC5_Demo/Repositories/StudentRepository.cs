using CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Models;
using DependencyInjectionUnityContainerMVC5_Demo.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DependencyInjectionUnityContainerMVC5_Demo.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<Student> GetStudentsWithCourse()
        {
            return Context.Students.Include(s => s.Course).Include(s => s.Instructor).ToList();
        }
    }
}
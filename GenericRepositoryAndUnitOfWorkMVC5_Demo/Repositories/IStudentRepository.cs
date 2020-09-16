using CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionUnityContainerMVC5_Demo.Repositories
{
    public interface IStudentRepository:IRepository<Student>
    {
        IEnumerable<Student> GetStudentsWithCourse();
    }
}

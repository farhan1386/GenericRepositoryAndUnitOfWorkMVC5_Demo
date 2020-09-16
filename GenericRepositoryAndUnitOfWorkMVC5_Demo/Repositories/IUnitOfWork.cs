using CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Models;
using System;

namespace DependencyInjectionUnityContainerMVC5_Demo.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> StudentRepository { get; }
        IRepository<Course> CourseRepositroy { get; }
        IRepository<Instructor> InstructorRepository { get; }
        IStudentRepository Students { get; }
        int Complete();
    }
}

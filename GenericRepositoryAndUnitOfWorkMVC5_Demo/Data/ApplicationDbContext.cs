using CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Models;
using System;
using System.Data.Entity;

namespace DependencyInjectionUnityContainerMVC5_Demo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("StudentCourseDB")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructor { get; set; }

        public static implicit operator ApplicationDbContext(DbSet<object> v)
        {
            throw new NotImplementedException();
        }
    }
}
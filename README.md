# Generic Repository And UnitOfWork MVC5

## What is the Repository Design Pattern in C#?
The Repository mediates between the domain and data mapping layers, acting like an in-memory collection of domain objects.

## Repository Pattern Goals
* Decouple Business code from data Access. As a result, the persistence Framework can be changed without a great effort
* Separation of Concerns
* Minimize duplicate query logic
* Testability

## Why we need the Repository Pattern in C#?
Nowadays, most of the data-driven applications need to access the data residing in one or more other data sources. Most of the time data sources will be a database. Again, these data-driven applications need to have a good and secure strategy for data access to perform the CRUD operations against the underlying database. One of the most important aspects of this strategy is the separation between the actual database, queries and other data access logic from the rest of the application. In our example, we need to separate the data access logic from the Employee Controller. The Repository Design Pattern is one of the most popular design patterns to achieve such separation between the actual database, queries and other data access logic from the rest of the application.

## Why the UnitOfWork and Repository pattern?
The UnitOfWork and repository patterns are intended to act like a abstraction layer between business logic and data access layer.
This can help insulate your application from changes in the data store and can facilitate automated unit testing / test driven development.

## What is Unit of Work
Maintains a list of objects affected by a business transaction and coordinates the writing out of changes.

## Consequences of the Unit of Work Pattern
* Increases the level of abstraction and keep business logic free of data access code
* Increased maintainability, flexibility and testability
* More classes and interfaces but less duplicated code
* The business logic is further away from the data because the repository abstracts the infrastructure. This has the effect that it might be harder to optimize certain operations which are performed against the data source.

## Implementing Generic Repository

    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int? id);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }

## Implementing Unit of Work

    public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> StudentRepository { get; }
        IRepository<Course> CourseRepositroy { get; }
        IRepository<Instructor> InstructorRepository { get; }
        IStudentRepository Students { get; }
        int Complete();
    }
    
    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
        }
        public IRepository<Student> StudentRepository => new Repository<Student>(db);

        public IRepository<Course> CourseRepositroy => new Repository<Course>(db);

        public IRepository<Instructor> InstructorRepository => new Repository<Instructor>(db);

        public IStudentRepository Students => new StudentRepository(db);

        public int Complete()
        {
            return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }

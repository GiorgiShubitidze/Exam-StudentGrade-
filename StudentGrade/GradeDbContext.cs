namespace StudentGrade
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GradeDbContext : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'StudentGrade.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public GradeDbContext()
            : base("name=GradeDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public DbSet<Student> Students { get; set; }
         public DbSet<Subject> Subjects { get; set; }
         public DbSet<StudentGrade> Grades { get; set; }
        //public DbSet<StudentInfoCsv> studentInfoCsvs { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
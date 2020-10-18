namespace StudentGrade.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GradeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GradeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var student = new List<Student>()
            {
                new Student(){StudentId=1,Name="Gio"},
                new Student(){StudentId=2,Name="Nika"},
                new Student(){StudentId=3,Name="Temo"},
                new Student(){StudentId=4,Name="Ika"},
                new Student(){StudentId=5,Name="Beka"},   //1,2,0
            };
            var subject = new List<Subject>()
                {
                    new Subject(){SubjectId=1,Name=".Net"},
                    new Subject(){SubjectId=2,Name="Entity FrameWork"},
                    new Subject(){SubjectId=34241,Name = "C++"},
                    new Subject(){SubjectId=4,Name = "C"},
                    new Subject(){SubjectId=5,Name = "OOP"},
                };
            context.Set<Student>().AddOrUpdate(s => s.Name, student.ToArray());
            context.Set<Subject>().AddOrUpdate(s => s.Name, subject.ToArray());
        }
    }
}


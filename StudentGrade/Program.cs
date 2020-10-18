using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Entity;

namespace StudentGrade
{
    class Program
    {
        static void Main()
        {

            string filecontents = File.ReadAllText("StudentPoint.csv");
            var lines = filecontents.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Skip(1);
            // [0] -> 1,1,5
            // [1] -> 2,5,8

            var students = new List<Student>();
            var subjects = new List<Subject>();

            using (var db = new GradeDbContext())
            {
                students = db.Students.ToList();
                subjects = db.Subjects.ToList();
            }

            var studentInfosCsv = new List<StudentInfoCsv>();
            foreach (var line in lines)
            {
                var studentInfoCsv = new StudentInfoCsv();
                var splittedLine = line.Split(',');
                studentInfoCsv.StudentIdCsv = Convert.ToInt32(splittedLine[0]);
                studentInfoCsv.SubjectIdCsv = Convert.ToInt32(splittedLine[1]);
                studentInfoCsv.PointCsv = Convert.ToInt32(splittedLine[2]);

                studentInfosCsv.Add(studentInfoCsv);
            }

            var notFoundStudents = new List<int>();
            var notFoundSubjects = new List<int>();

            using (var db = new GradeDbContext())
            {

                foreach (var studentInfo in studentInfosCsv)
                {
                    if (students.FirstOrDefault(s => s.StudentId == studentInfo.StudentIdCsv) == null)
                    {
                        notFoundStudents.Add(studentInfo.StudentIdCsv);
                    }
                    else if (subjects.FirstOrDefault(s => s.SubjectId == studentInfo.SubjectIdCsv) == null)
                    {
                        notFoundSubjects.Add(studentInfo.SubjectIdCsv);
                    }
                    else
                    {
                        var studentGrade = new StudentGrade
                        {
                            Point = studentInfo.PointCsv,
                            StudentId = studentInfo.StudentIdCsv,
                            SubjectId = studentInfo.SubjectIdCsv
                        };

                        db.Grades.Add(studentGrade);
                    }
                }

                db.SaveChanges();
            }

            foreach (var id in notFoundStudents)
            {
                Console.WriteLine("Not found student id: " + id);
            }

            foreach (var id in notFoundSubjects)
            {
                Console.WriteLine("Not found subject id: " + id);
            }
        }
    }



}

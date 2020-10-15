using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentGrade
{
    class Program
    {
        static void Main()
        {
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

            string filecontents = File.ReadAllText("StudentPoint.csv");
            var lines = filecontents.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var data = new List<StudentGrade>();
            StudentGrade my = new StudentGrade();
            Student std = new Student();
            foreach (var line in lines)
            {
                var split = line.Split(',');
                // split.Skip(3);

                my = new StudentGrade();
                my.StudentCsvId = Convert.ToInt32(split[0]);
                my.SubjectCsvId = Convert.ToInt32(split[1]);
                my.PointCsv = Convert.ToInt32(split[2]);
                // data.Add(line.Split(','));
                // var x = line.Split(',');
                data.Add(my);
            }
            foreach (var item in data)
            {
                //var stName = student.Where(a => a.StudentId == item.StudentCsvId).FirstOrDefault();
               // var sbName = subject.Where(a => a.SubjectId == item.SubjectCsvId).FirstOrDefault();
                var res = student.Where(a => a.StudentId == item.StudentCsvId).FirstOrDefault();
                var res1 = subject.Where(a => a.SubjectId == item.SubjectCsvId).FirstOrDefault();
                if (res == null || res1 == null) Console.WriteLine($"Student Name = {res} ,Student Id = {item.StudentCsvId} " +
                    $", Subject Name  = {res1}  Subject = {item.SubjectCsvId} , Point = {item.PointCsv} , Status - Not Imported ");
                if (res != null && res1 != null)
                {

                    item.StudentId = item.StudentCsvId;
                    item.SubjectId = item.SubjectCsvId;
                    item.Point = item.PointCsv;
                    
                    //if (item.StudentId==0)
                    //{
                    //    Console.WriteLine($"Not imported {item.CsvStudentId}");
                    //}

                    Console.WriteLine($" Student Name = {res} ,Student Id = {item.StudentId} ,Subject Name =  {res1} ,Subject = {item.SubjectId} , Point = {item.Point} , Status - Imported ");
                }
            }

            Console.ReadLine();
        }
    }
}

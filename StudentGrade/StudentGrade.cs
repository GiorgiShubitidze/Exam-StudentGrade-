using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrade
{
    public class StudentGrade 
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Point { get; set; }
        public int StudentCsvId { get; set; }
        public int SubjectCsvId { get; set; }
        public int PointCsv { get; set; }
        public Student student { get; set; }
        public Subject subject { get; set; }

        public string StudentName { get; set; }

         

        public override string ToString()
        {
            return $"Point : {Point}  Name : ";
        }
    }
}

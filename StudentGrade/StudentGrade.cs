using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrade
{
    public class StudentGrade 
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Point { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
    public class StudentInfoCsv
    {
        public int StudentIdCsv { get; set; }

        public int SubjectIdCsv { get; set; }

        public int PointCsv { get; set; }
    }
}

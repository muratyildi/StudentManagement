using Entites.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Maps
{
    public class StudentCourseMap
    {
        public long StudentId { get; set; }
        public Student Student { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; }
    }
}

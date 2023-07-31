using Entites.Abstracts;
using Entites.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Course:EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }

        #region Collection
        public List<Grade> Grades { get; set; }
        public List<StudentCourseMap> StudentMaps { get; set; }
        #endregion
        public Course()
        {
            StudentMaps = new List<StudentCourseMap>();
        }
    }
}

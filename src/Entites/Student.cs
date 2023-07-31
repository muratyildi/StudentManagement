using Entites.Abstracts;
using Entites.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Student : EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string BirthDay { get; set; }
        public string TCId { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string HighSchool { get; set; }
        public int DiplomaScore { get; set; }
        public string Certificate { get; set; }
        public string Success { get; set; }
        public int ProfileOccupancyRate { get; set; }

        #region Collection
        public List<StudentCourseMap> CourseMaps { get; set; }
        public List<Grade> Grades { get; set; }
        #endregion
        public Student()
        {
            CourseMaps = new List<StudentCourseMap>();
        }
    }
}

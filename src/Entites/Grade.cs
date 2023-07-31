using Entites.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Grade:EntityBase
    {
        public long Id { get; set; }
        public long CourseId { get; set; }
        public long StudentId { get; set; }
        public int Point { get; set; }

        #region Single
        public Student Student { get; set; }
        public Course Course { get; set; }
        #endregion
    }
}

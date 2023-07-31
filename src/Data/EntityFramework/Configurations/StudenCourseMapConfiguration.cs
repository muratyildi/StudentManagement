using Entites.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Configurations
{
    public class StudenCourseMapConfiguration : IEntityTypeConfiguration<StudentCourseMap>
    {
        public void Configure(EntityTypeBuilder<StudentCourseMap> builder)
        {
            builder.HasKey(x => new { x.StudentId, x.CourseId});

            builder.HasOne(x => x.Student).WithMany(x => x.CourseMaps).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Course).WithMany(x => x.StudentMaps).HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

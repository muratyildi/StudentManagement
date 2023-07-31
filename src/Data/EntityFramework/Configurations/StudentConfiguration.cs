using Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Name).IsRequired();
            builder.Property(x => x.City)   ;
            builder.Property(x => x.BirthDay);
            builder.Property(x => x.Success);
            builder.Property(x => x.Certificate);
            builder.Property(x => x.DiplomaScore);
            builder.Property(x => x.Email);
            builder.Property(x => x.Phone);
            builder.Property(x => x.TCId);
            builder.Property(x => x.HighSchool);
        }
    }
}

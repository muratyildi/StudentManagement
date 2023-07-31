using AutoMapper;
using Entites;

namespace Admin.API.Models
{
    public class CourseUpdate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
    }
    public class CourseUpdateProfile:Profile
    {
        public CourseUpdateProfile()
        {
            CreateMap<CourseUpdate, Course>();
        }
    }
}

using AutoMapper;
using Entites;

namespace Admin.API.Models.Dtos
{
    public class CourseCreateModel
    {
        public string Name { get; set; }
        public int Credit { get; set; }
    }
    public class CourseCreateModelProfile:Profile {
        public CourseCreateModelProfile()
        {
            CreateMap<CourseCreateModel, Course>();
        }
    }
}

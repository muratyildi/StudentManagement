using AutoMapper;
using Entites;

namespace Admin.API.Models.Dtos
{
    public class GetCoursesDto
    {
        public List<CourseModel> Courses { get; set; }
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalItemCount { get; set; }

        public int TotalPageCount { get; set; }
        public GetCoursesDto()
        {
            Courses = new List<CourseModel>();
        }
        public class CourseModel
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public int Credit { get; set; }
        }
    }
    public class GetCourseDtoProfile : Profile
    {
        public GetCourseDtoProfile()
        {
            CreateMap<Course, GetCoursesDto.CourseModel>();
        }
    }
}

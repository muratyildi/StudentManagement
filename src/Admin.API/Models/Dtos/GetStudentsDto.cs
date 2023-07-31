using AutoMapper;
using Entites;
using Entites.Maps;

namespace Admin.API.Models.Dtos
{
    public class GetStudentsDto
    {
        public List<StudentModel> Students { get; set; }
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalItemCount { get; set; }

        public int TotalPageCount { get; set; }
        public GetStudentsDto()
        {
            Students = new List<StudentModel>();
        }
        public class StudentModel
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string HighSchool { get; set; }
            public int DiplomaScore { get; set; }
            public string Certificate { get; set; }
            public string Success { get; set; }

            public List<StudentCourseMapModel> CourseMaps { get; set; }
            
        }

        public class StudentCourseMapModel
        {
            public CourseModel Course { get; set; }
        }
        public class CourseModel
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public int Credit { get; set; }
            public List<GradeModel> Grades { get; set; }
        }

        public class GradeModel
        {
            public long Id { get; set; }
            public int Point { get; set; }
        }
    }
    public class GetStudentDtoProfile : Profile
    {
        public GetStudentDtoProfile()
        {
            CreateMap<Student,GetStudentsDto.StudentModel>();
            CreateMap<StudentCourseMap,GetStudentsDto.StudentCourseMapModel>();
            CreateMap<Grade,GetStudentsDto.GradeModel>();
            CreateMap<Course,GetStudentsDto.CourseModel>();
        }
    }
}

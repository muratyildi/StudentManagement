using AutoMapper;
using Entites;

namespace Admin.API.Models.Dtos
{
    public class FindStudentDto
    {
        public StudentModel Student { get; set; }
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
        }
    }
    public class FindStudentDtoProfile : Profile
    {
        public FindStudentDtoProfile()
        {
            CreateMap<Student,FindStudentDto.StudentModel>();
        }
    }
}

using AutoMapper;
using Entites;

namespace Admin.API.Models
{
    public class StudentUpdate
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
    public class StudentUpdateProfile:Profile
    {
        public StudentUpdateProfile()
        {
            CreateMap<StudentUpdate, Student>();
        }
    }
}

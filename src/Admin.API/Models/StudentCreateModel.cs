using AutoMapper;
using Entites;
using System.ComponentModel.DataAnnotations;

namespace Admin.API.Models
{
    public class StudentCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string BirthDay { get; set; }
        [Required]
        public string TCId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string HighSchool { get; set; }
        [Required]
        public int DiplomaScore { get; set; }
        [Required]
        public string Certificate { get; set; }
        [Required]
        public string Success { get; set; }
        [Required]
        public int ProfileOccupancyRate { get; set; }
    }
    public class StudentCreateModelProfile : Profile
    {
        public StudentCreateModelProfile()
        {
            CreateMap<StudentCreateModel, Student>();
        }
    }
}

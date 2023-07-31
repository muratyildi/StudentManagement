using AutoMapper;
using Entites;

namespace Admin.API.Models
{
    public class AddGradeModel
    {
        public long CourseId { get; set; }
        public int Point { get; set; } 
    }
    public class AddGradeModelProfile : Profile
    {
        public AddGradeModelProfile()
        {
            CreateMap<AddGradeModel, Grade>();
        }
    }
}

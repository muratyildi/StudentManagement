using Admin.API.Models;
using AutoMapper;
using Data.EntityFramework;
using Data.Repositories;
using Entites;
using Entites.Maps;
using Infrastructure.Web.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Admin.API.Controllers
{
    [Route("api/v1/students")]
    [ApiController]
    public class StudentCourseController : Controller
    {
        private readonly IRepository<StudentCourseMap> _studentCourseMapRepository;

        public StudentCourseController(IRepository<StudentCourseMap> studentCourseMapRepository)
        {
            _studentCourseMapRepository = studentCourseMapRepository;
        }

        [HttpPost("{studentId}/courses")]
        public async Task<ApiResult> AddCourse(AddCourseModel model, long studentId)
        {
            try
            {
                var map = new StudentCourseMap
                {
                    CourseId = model.CourseId,
                    StudentId = studentId,
                };

                await _studentCourseMapRepository.Add(map);
                return new ApiResult(ApiStatusDefaults.Success, "success", map);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

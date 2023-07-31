using Admin.API.Models.Dtos;
using Admin.API.Models;
using AutoMapper;
using Data.EntityFramework;
using Data.Repositories;
using Entites;
using Infrastructure.Web.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Entities;

namespace Admin.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CoursesController(IRepository<Course> courseRepository, IMapper mapper, DataContext dataContext)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ApiResult> Get(long? courseId, int page = 1, int size = 10)
        {
            Expression<Func<Course, bool>> filter = x => true;

            if (courseId.HasValue)
            {
                var prefix = filter.Compile();
                filter = x => prefix(x) && x.Id == courseId;
            }

            var course = await _courseRepository.GetByFilter<GetCoursesDto.CourseModel>(filter, x => x.Id, true, page, size);

            var dto = new GetCoursesDto
            {
                Courses = course.ToList(),
                PageNumber = course.PageNumber,
                PageSize = course.PageSize,
                TotalItemCount = course.TotalItemCount,
                TotalPageCount = course.PageCount
            };

            return new ApiResult(ApiStatusDefaults.Success, "", dto);
        }

        [HttpPost]
        public async Task<ApiResult> Post(CourseCreateModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new ApiResult(ApiStatusDefaults.ValidationError, "Lütfen tüm bilgileri eksiksiz giriniz.");

                var course = _mapper.Map<Course>(model);

                await _courseRepository.Add(course);

                await _dataContext.SaveChangesAsync();

                return new ApiResult(ApiStatusDefaults.Success);
            }
            catch (Exception e)
            {
                return new ApiResult(ApiStatusDefaults.Error, e.ToString());
            }
        }
          
        [HttpPut]
        public async Task<ApiResult> Put([FromForm] CourseUpdate model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new ApiResult(ApiStatusDefaults.ValidationError, "Lütfen tüm bilgileri eksiksiz giriniz.");

                var course = await _courseRepository.GetById(model.Id);

                course = _mapper.Map(model, course);

                _courseRepository.Update(course);

                await _dataContext.SaveChangesAsync();

                return new ApiResult(ApiStatusDefaults.Success);
            }
            catch (Exception e)
            {
                return new ApiResult(ApiStatusDefaults.Error, e.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(long id)
        {
            try
            {
                var course = await _courseRepository.GetById(id);
                var deletedCourse = _courseRepository.Delete(course);
                return new ApiResult(ApiStatusDefaults.Success, deletedCourse.ToString());
            }
            catch (Exception e)
            {
                return new ApiResult(ApiStatusDefaults.Error, e.ToString());
            }
        }
    }
}

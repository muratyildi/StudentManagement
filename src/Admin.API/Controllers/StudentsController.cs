using Admin.API.Models;
using Admin.API.Models.Dtos;
using Amazon.S3.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.EntityFramework;
using Data.Repositories;
using Entites;
using Entites.Maps;
using Entities;
using Infrastructure.Web.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq.Expressions;
using System.Security.Policy;
using X.PagedList;

namespace Admin.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<StudentCourseMap> _studentCourseMapRepository;
        private readonly IMapper _mapper;

        public StudentsController(IRepository<Student> studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ApiResult> Get(long? studentId, int page = 1, int size = 10)
        {
            Expression<Func<Student, bool>> filter = x => true;

            if (studentId.HasValue)
            {
                var prefix = filter.Compile();
                filter = x => prefix(x) && x.Id == studentId;
            }

            var students = await _studentRepository.GetByFilter<GetStudentsDto.StudentModel>(filter, x => x.ProfileOccupancyRate, true, page, size);

            var dto = new GetStudentsDto
            {
                Students = students.ToList(),
                PageNumber = students.PageNumber,
                PageSize = students.PageSize,
                TotalItemCount = students.TotalItemCount,
                TotalPageCount = students.PageCount
            };

            return new ApiResult(ApiStatusDefaults.Success, "", dto);
        }

        [HttpPost]
        public async Task<ApiResult> Post(StudentCreateModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new ApiResult(ApiStatusDefaults.ValidationError, "Lütfen tüm bilgileri eksiksiz giriniz.");

                var student = _mapper.Map<Student>(model);

                student.ProfileOccupancyRate = CalculateProfileOccupancyRate(student);

                await _studentRepository.Add(student);

                return new ApiResult(ApiStatusDefaults.Success);
            }
            catch (Exception e)
            {
                return new ApiResult(ApiStatusDefaults.Error, e.ToString());
            }
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromForm] StudentUpdate model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new ApiResult(ApiStatusDefaults.ValidationError, "Lütfen tüm bilgileri eksiksiz giriniz.");

                var student = await _studentRepository.GetById(model.Id);

                student = _mapper.Map(model, student);

                _studentRepository.Update(student);

                return new ApiResult(ApiStatusDefaults.Success);
            }
            catch (Exception e)
            {
                return new ApiResult(ApiStatusDefaults.Error, e.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<ApiResult> Get(long id)
        {


            var student = await _studentRepository.GetById(id);

            var dto = new FindStudentDto
            {
                Student = new FindStudentDto.StudentModel
                {
                    Id = id,
                    Name = student.Name,
                    Email = student.Email,
                    Phone = student.Phone,
                    HighSchool = student.HighSchool,
                    DiplomaScore = student.DiplomaScore,
                    Certificate = student.Certificate,
                    Success = student.Success
                }

            };

            return new ApiResult(ApiStatusDefaults.Success, "", dto);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(long id)
        {
            try
            {
                var student = await _studentRepository.GetById(id);
                var deletedStudent = _studentRepository.Delete(student);
                return new ApiResult(ApiStatusDefaults.Success, deletedStudent.ToString());
            }
            catch (Exception e)
            {
                return new ApiResult(ApiStatusDefaults.Error, e.ToString());
            }
        }

        private int CalculateProfileOccupancyRate(Student student)
        {
            var profileOccupancyRate = 0;

            if (!string.IsNullOrEmpty(student.Name))
                profileOccupancyRate += 10;

            if (!string.IsNullOrEmpty(student.TCId))
                profileOccupancyRate += 10;

            if (!string.IsNullOrEmpty(student.Success))
                profileOccupancyRate += 10;

            if (!string.IsNullOrEmpty(student.Certificate))
                profileOccupancyRate += 10;

            if (!string.IsNullOrEmpty(student.BirthDay))
                profileOccupancyRate += 10;

            if (!string.IsNullOrEmpty(student.City))
                profileOccupancyRate += 10;

            if (student.DiplomaScore > 0)
                profileOccupancyRate += 10;

            if (!string.IsNullOrEmpty(student.Email))
                profileOccupancyRate += 10;

            if (!string.IsNullOrEmpty(student.Phone))
                profileOccupancyRate += 10;

            if (!string.IsNullOrEmpty(student.HighSchool))
                profileOccupancyRate += 10;

            return profileOccupancyRate;
        }
    }
}

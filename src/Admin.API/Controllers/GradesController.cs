using AutoMapper;
using Data.EntityFramework;
using Data.Repositories;
using Entites.Maps;
using Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Infrastructure.Web.Constants;
using Admin.API.Models;

namespace Admin.API.Controllers
{
    [Route("api/v1/students")]
    [ApiController]
    public class GradesController : Controller
    {
        private readonly IRepository<Grade> _gradeRepository;
        private readonly IMapper _mapper;

        public GradesController(IRepository<Grade> gradeRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        [HttpPost("{studentId}/grades")]
        public async Task<ApiResult>Post(AddGradeModel model,long studentId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new ApiResult(ApiStatusDefaults.ValidationError, "Lütfen tüm bilgileri eksiksiz giriniz.");

                var grade = _mapper.Map<Grade>(model);
                grade.StudentId = studentId;

                await _gradeRepository.Add(grade);

                return new ApiResult(ApiStatusDefaults.Success);
            }
            catch (Exception e)
            {

                return new ApiResult(ApiStatusDefaults.Error, e.ToString()); ;
            }
        }
    }
}

using CoreApiResponse;
using dapper.sql.api.Models;
using dapper.sql.api.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace dapper.sql.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : BaseController
    {
        IStudentRepository studentRepository;
        public StudentController(IStudentRepository studentRepository) { 
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            try
            {
                return CustomResult("Data load successfully.",await studentRepository.GetAll());
            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return CustomResult("Data load successfully.",await studentRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Student student)
        {
            try
            {
                bool isSaved = await studentRepository.Add(student);
                if(isSaved)
                {
                    return CustomResult("Student has been saved.", student);
                }
                return CustomResult("Student saved failed.", HttpStatusCode.BadRequest);
                
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Student student)
        {
            try
            {
                bool isUpdated = await studentRepository.Edit(student);
                if (isUpdated)
                {
                    return CustomResult("Student has been modified.", student);
                }
                return CustomResult("Student modified failed.", HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool isDeleted = await studentRepository.Delete(id);
                if (isDeleted)
                {
                    return CustomResult("Student has been deleted.");
                }
                return CustomResult("Student deleted failed.", HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}

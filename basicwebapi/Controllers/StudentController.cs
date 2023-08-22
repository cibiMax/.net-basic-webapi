using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using BasicWebApi.IService.IService;
using BasicWebApi.IService.Service;
using BasicWebApi.ViewModel.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace basicwebapi.Controllers
{
  //  [Authorize(Roles ="Admin,User")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;

        }
        [HttpPost]
        [Authorize(Roles = "User")]
        [Route("Create")]
        async public Task<IActionResult> InsertStudent([FromBody] StudentVm student)
        {
            await _studentService.InsertStudent(student);

            return Ok(student);


        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("GetAll")]
        public IActionResult GetStudents()
        {
            List<StudentVm> students = _studentService.GetStudents();

            return Ok(students);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        [Route("GetById")]
        public IActionResult GetStudentById(int id)
        {
            StudentVm students = _studentService.GetStudentById(id);

            return Ok(students);
        }
        [HttpPut]
        [Authorize(Roles = "User")]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] StudentVm student)
        {
            _studentService.UpdateStudent(student);
            return Ok();
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("DeleteStudent")]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return Ok();
        }



    }
}

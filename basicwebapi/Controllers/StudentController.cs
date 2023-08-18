using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using BasicWebApi.IService.IService;
using BasicWebApi.IService.Service;

using BasicWEbApi.Models.Models;

namespace basicwebapi.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
    
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
         
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult InsertStudent([FromBody]Student student)
        {
            int rval= _studentService.InsertStudent(student);
           
                return  Ok(student);
            
     
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetStudents()
        {
            List<Student> students=_studentService.GetStudents();
           
            return Ok(students);
        }
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetStudentById(int id)
        {
            Student students = _studentService.GetStudentById(id);

            return Ok(students);
        }
        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody]Student student) {
            _studentService.UpdateStudent(student);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteStudent")]
        public IActionResult Delete(int id) {
            _studentService.DeleteStudent(id);
            return Ok();
        }



    }
}

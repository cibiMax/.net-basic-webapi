using BasicWebApi.IService.IService;
using BasicWebApi.Model.Models;
using BasicWEbApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.IService.Service
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StudentService(ApplicationDbContext application)
        {
            _applicationDbContext = application;
        }

        public void DeleteStudent(int id)
        {
         Student s1=   _applicationDbContext.students.FirstOrDefault(a=>a.Id==id);
            _applicationDbContext.Remove(s1);
            _applicationDbContext.SaveChanges();
            return;

        }

        public Student GetStudentById(int id)
        {
        return   _applicationDbContext.students.FirstOrDefault(a=>a.Id==id);
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            students = _applicationDbContext.students.ToList<Student>();
            return students;
        }

        public int InsertStudent(Student student)
        {
            _applicationDbContext.students.Add(student);
            return _applicationDbContext.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _applicationDbContext.students.Update(student);
            _applicationDbContext.SaveChanges();
            return;
        }
    }
}

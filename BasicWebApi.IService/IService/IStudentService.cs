using BasicWEbApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.IService.IService
{
    public interface IStudentService
    {
        public int InsertStudent(Student student);

        public List<Student> GetStudents();

        public Student GetStudentById(int id);
        public void UpdateStudent(Student student);

        public void DeleteStudent(int id);

    }
}

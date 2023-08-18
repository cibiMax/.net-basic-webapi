using BasicWebApi.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.IService.IService
{
    public interface IStudentService
    {
        public Task<int>InsertStudent(StudentVm student);

        public List<StudentVm> GetStudents();

        public StudentVm GetStudentById(int id);
        public void UpdateStudent(StudentVm student);

        public void DeleteStudent(int id);

    }
}

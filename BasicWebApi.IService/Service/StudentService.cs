using AutoMapper;
using basicwebapi.Models;
using BasicWebApi.IService.IService;

using BasicWebApi.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.IService.Service
{
    public class StudentService : IStudentService
    {
        private readonly  ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public StudentService(ApplicationDbContext application,IMapper mapper)
        {
            _applicationDbContext = application;
            _mapper = mapper;
        }

        public void DeleteStudent(int id)
        {
         Student s1=   _applicationDbContext.students.FirstOrDefault(a=>a.Id==id);
            _applicationDbContext.Remove(s1);
            _applicationDbContext.SaveChanges();
            return;

        }

        public StudentVm GetStudentById(int id)
        {
        return  _mapper.Map<Student,StudentVm>( _applicationDbContext.students.FirstOrDefault(a=>a.Id==id));
        }

        public List<StudentVm> GetStudents()
        {
            List<StudentVm> students = _mapper.Map<List<Student>, List<StudentVm>>(_applicationDbContext.students.ToList());
            return students;
        }

     async   public Task<int> InsertStudent(StudentVm student)
        {
        Student s=    _mapper.Map<StudentVm, Student>(student);
        await  _applicationDbContext.students.AddAsync(s);
            return _applicationDbContext.SaveChanges();
        }

        public void UpdateStudent(StudentVm student)
        {
            _applicationDbContext.students.Update(   _mapper.Map<StudentVm, Student>(student));
            _applicationDbContext.SaveChanges();
            return;
        }
    }
}

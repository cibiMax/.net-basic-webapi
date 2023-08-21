using AutoMapper;
using basicwebapi.Models;

using BasicWebApi.ViewModel.ViewModels;


namespace basicwebapi
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student,StudentVm>();
            CreateMap<StudentVm, Student>();
            CreateMap<UserVm, User>();


        }
       
    }
}

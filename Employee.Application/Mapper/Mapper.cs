using AutoMapper;
using Employee.Application.DTO;
using Employee.Core.Entities;

namespace Employee.Application.Mapper
{
    public class Mapper :Profile
    {
        public Mapper() 
        {
            CreateMap<Employe, EmployeeDTO>().ReverseMap();
            CreateMap<RegisterDTO, Employe>().ReverseMap();
            CreateMap<Employe, RegisterDTO>().ReverseMap();
            CreateMap<Employe, UpdateEmployeeDTO>().ReverseMap();
            CreateMap<UpdateEmployeeDTO, Employe>().ReverseMap();

        }
    }
}

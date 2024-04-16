using AutoMapper;
using EmployeeManagement.DTO;
using EmployeeManagement.Model;

namespace EmployeeManagement.Mapper;

public class RegistrationMapper : Profile
{
    public RegistrationMapper()
        {
            CreateMap<RegistrationDTO,Employee>().ReverseMap();
        }
}
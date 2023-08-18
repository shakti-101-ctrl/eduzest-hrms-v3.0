using AutoMapper;
using Eduzest.HRMS.Entities.Entities.Admin;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Entities.Entities.Log;
using Eduzest.HRMS.Repository.DTO;
using Eduzest.HRMS.Repository.DTO.Admin;
using Eduzest.HRMS.Repository.DTO.DbLog;
using Eduzest.HRMS.Repository.DTO.Employee;

namespace Eduzest.HRMS.WebApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            //branch
            CreateMap<Branch,GetBranchDto>().ReverseMap();
            CreateMap<Branch, AddBranchDto>().ReverseMap();
            CreateMap<Branch, UpdateBranchDto>().ReverseMap();
            CreateMap<Branch, Repository.DTO.BranchDto>().ReverseMap();
            //department
            CreateMap<Department, GetDepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();
            CreateMap<Department,AddDepartmentDto>().ReverseMap();

            //designation
            CreateMap<Designation, GetDesignationDto>().ReverseMap();
            CreateMap<Designation, UpdateDesignationDto>().ReverseMap();
            CreateMap<Designation, AddDesignationDto>().ReverseMap();

            //employeedetails
            CreateMap<EmployeeDetails, GetEmployeeDetailsDto>().ReverseMap();
            CreateMap<EmployeeDetails, UpdateEmployeeDetailsDto>().ReverseMap();
            CreateMap<EmployeeDetails, AddEmployeeDetailsDto>().ReverseMap();


            CreateMap<Registration, RegistrationDto>().ReverseMap();
            

           
        }
    }
}

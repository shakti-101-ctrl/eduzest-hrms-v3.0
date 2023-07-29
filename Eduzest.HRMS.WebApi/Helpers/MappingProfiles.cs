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
            CreateMap<Branch,GetBranchDto>().ReverseMap();
            CreateMap<Branch, AddBranchDto>().ReverseMap();
            CreateMap<Branch, UpdateBranchDto>().ReverseMap();
            //CreateMap<AddBranchDto,Branch>().ReverseMap();
            //CreateMap<UpdateBranchDto,BranchDto>().ReverseMap();
            CreateMap<Registration, RegistrationDto>().ReverseMap();
            

           
        }
    }
}

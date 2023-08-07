using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO;
using Eduzest.HRMS.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Interface
{
    public interface IDesignation: IGenericRepository<Designation>
    {
        Task<ServiceResponse<List<GetDesignationDto>>> GetAllDesignation();
        Task<ServiceResponse<GetDesignationDto>> AddDesignation(AddDesignationDto designationDto);
        Task<ServiceResponse<GetDesignationDto>> UpdateDesignation(UpdateDesignationDto updateDesignationDto, Guid? id);
        Task<ServiceResponse<GetDesignationDto>> DeleteDesignation(Guid deignationId);
        Task<ServiceResponse<GetDesignationDto>> GetDesignationById(Guid designationId);

    }
}

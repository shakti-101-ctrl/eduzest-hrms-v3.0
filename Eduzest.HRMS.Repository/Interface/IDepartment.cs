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
    public interface IDepartment : IGenericRepository<Department>
    {
        Task<ServiceResponse<List<GetDepartmentDto>>> GetAllDepartments();
        Task<ServiceResponse<GetDepartmentDto>> AddDepartments(AddDepartmentDto addDepartmentDto);
        Task<ServiceResponse<GetDepartmentDto>> UpdateDepartments(UpdateDepartmentDto updateDepartmentDto, Guid? id);
        Task<ServiceResponse<GetDepartmentDto>> DeleteDepartment(Guid deptId);
        Task<ServiceResponse<GetDepartmentDto>> GetDepartmentById(Guid deptid);

        Task<ServiceResponse<List<GetDepartmentDto>>> GetAllDepartmentsByBranch(Guid? branchid);
    }
}

using Eduzest.HRMS.Repository.DTO;
using Eduzest.HRMS.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Interface
{
    public interface IEmployeeDetails
    {
        Task<ServiceResponse<List<GetEmployeeDetailsDto>>> GetAllEmployee();
        Task<ServiceResponse<GetEmployeeDetailsDto>> AddEmployeeDetails(AddEmployeeDetailsDto employeeDetailsDto);
        Task<ServiceResponse<GetEmployeeDetailsDto>> UpdateEmployeeDetails(UpdateEmployeeDetailsDto updateEmployeeDetailsDto, string id);
        Task<ServiceResponse<GetEmployeeDetailsDto>> DeleteEmployeeDetails(string employeecode);
        Task<ServiceResponse<GetEmployeeDetailsDto>> GetEmployeeByEmpCode(string empcode);
    }
}

using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduzest.HRMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BranchController> _logger;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public EmployeeController(DataContext datacontext, IUnitOfWork unitOfWork, IMapper mapper, ILogger<BranchController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _dataContext = datacontext;
        }
        [HttpGet("getemployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _unitOfWork.EmployeeDetails.GetAllEmployee());
            }
            catch (Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response = (int)ResponseType.InternalServerError });
            }

        }

        [HttpGet("getemployeebycode")]
        public async Task<IActionResult> GetBranchById(string empcode)
        {
            var result = await _unitOfWork.EmployeeDetails.GetEmployeeByEmpCode(empcode);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.UnAuthenticatedRequest, Response = (int)ResponseType.UnAuthenticatedAccess, Success = false });
            }
        }
        [HttpPost("postemployee")]
        public async Task<IActionResult> PostBranch(AddEmployeeDetailsDto addEmployeeDetailsDto)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //branchDto.CreatedOn = DateTime.Now;
                    var result = await _unitOfWork.EmployeeDetails.AddEmployeeDetails(addEmployeeDetailsDto);
                    _unitOfWork.Dispose();
                    return Ok(result);
                }
                else
                {
                    return Ok(new ServiceResponse<Branch>() { Message = MessaageType.UnAuthenticatedRequest, Response = (int)ResponseType.UnAuthenticatedAccess, Success = false });

                }

            }
            catch (Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response = (int)ResponseType.InternalServerError });
            }

        }
        [HttpPut("putemployee/{id}")]
        public async Task<IActionResult> PutEmployee(UpdateEmployeeDetailsDto updateEmployeeDetailsDto, string id)
        {
            try
            {
                var result = await _unitOfWork.EmployeeDetails.UpdateEmployeeDetails(updateEmployeeDetailsDto, id);
                _unitOfWork.Dispose();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response = (int)ResponseType.InternalServerError });
            }

        }
        [HttpDelete("deleteemployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            try
            {
                var employee = await _dataContext.EmployeeDetails.Where(x => x.Employeecode == id).FirstOrDefaultAsync();
                if (employee != null)
                {
                    
                    var result = await _unitOfWork.EmployeeDetails.DeleteEmployeeDetails(id);
                    _unitOfWork.Dispose();
                    return Ok(result);
                }
                else
                {
                    return Ok(new ServiceResponse<Branch>() { Message = MessaageType.UnAuthenticatedRequest, Response = (int)ResponseType.UnAuthenticatedAccess, Success = false });
                }
            }
            catch (Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response = (int)ResponseType.InternalServerError });
            }

        }

    }
}

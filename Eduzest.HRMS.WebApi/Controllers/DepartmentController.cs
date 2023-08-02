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
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BranchController> _logger;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public DepartmentController(DataContext datacontext, IUnitOfWork unitOfWork, IMapper mapper, ILogger<BranchController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _dataContext = datacontext;
        }
        [HttpGet("getdepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                return Ok(await _unitOfWork.Departments.GetAllDepartments());
            }
            catch (Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response = (int)ResponseType.InternalServerError });
            }

        }

        [HttpGet("getdepartmentbyid/{id}")]
        public async Task<IActionResult> GetBranchById(Guid id)
        {
            var result = await _unitOfWork.Departments.GetDepartmentById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.UnAuthenticatedRequest, Response = (int)ResponseType.UnAuthenticatedAccess, Success = false });
            }
        }
        [HttpPost("postdepartment")]
        public async Task<IActionResult> PostBranch(AddDepartmentDto addDepartment)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //branchDto.CreatedOn = DateTime.Now;
                    var result = await _unitOfWork.Departments.AddDepartments(addDepartment);
                    await _unitOfWork.Complete();
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
        [HttpPut("putdepartment/{id}")]
        public async Task<IActionResult> PutDepartment(UpdateDepartmentDto updateDepartmentDto, Guid? id)
        {
            try
            {
                var result = await _unitOfWork.Departments.UpdateDepartments(updateDepartmentDto, id);
                await _unitOfWork.Complete();
                _unitOfWork.Dispose();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response = (int)ResponseType.InternalServerError });
            }

        }
        [HttpDelete("deletedepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            try
            {
                var department = await _dataContext.Departments.Where(x => x.DeptId == id).FirstOrDefaultAsync();
                if (department != null)
                {
                    //department.IsActive = false;
                    var result = await _unitOfWork.Departments.DeleteDepartment(id);
                    await _unitOfWork.Complete();
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

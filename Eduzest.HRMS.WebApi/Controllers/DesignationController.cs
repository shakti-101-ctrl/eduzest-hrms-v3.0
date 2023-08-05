using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eduzest.HRMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BranchController> _logger;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public DesignationController(DataContext datacontext, IUnitOfWork unitOfWork, IMapper mapper, ILogger<BranchController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _dataContext = datacontext;
        }
        [HttpGet("getbranches")]
        public async Task<IActionResult> GetAllDesignation()
        {
            try
            {
                return Ok(await _unitOfWork.Designation.GetAllDesignation());
            }
            catch (Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response = (int)ResponseType.InternalServerError });
            }

        }

        [HttpGet("getdesignationbyid")]
        public async Task<IActionResult> GetBranchById(Guid designationid)
        {
            var result = await _unitOfWork.Designation.GetDesignationById(designationid);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.UnAuthenticatedRequest, Response = (int)ResponseType.UnAuthenticatedAccess, Success = false });
            }
        }
        [HttpPost("postdesignation")]
        public async Task<IActionResult> PostBranch(AddDesignationDto addDesignationDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _unitOfWork.Designation.AddDesignation(addDesignationDto);
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
        [HttpPut("putdesignation/{id}")]
        public async Task<IActionResult> PutBranch(UpdateDesignationDto updateDesignationDto, Guid? id)
        {
            try
            {
                var result = await _unitOfWork.Designation.UpdateDesignation(updateDesignationDto, id);
                _unitOfWork.Dispose();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response = (int)ResponseType.InternalServerError });
            }

        }
        [HttpDelete("deletedesigantion/{id}")]
        public async Task<IActionResult> DeleteBranch(Guid id)
        {
            try
            {
                    var result = await _unitOfWork.Designation.DeleteDesignation(id);
                    _unitOfWork.Dispose();
                    return Ok(result);  
            }
            catch (Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response = (int)ResponseType.InternalServerError });
            }

        }

    }
}

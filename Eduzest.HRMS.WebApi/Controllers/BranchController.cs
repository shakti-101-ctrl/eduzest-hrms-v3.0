using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Service;
using Eduzest.HRMS.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;
namespace Eduzest.HRMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BranchController> _logger;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public BranchController(DataContext datacontext, IUnitOfWork unitOfWork, IMapper mapper, ILogger<BranchController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _dataContext = datacontext;
        }
        [HttpGet("getbranches")]
        public async Task<IActionResult> GetBranches()
        {
            try
            {
                return Ok(await _unitOfWork.Branches.GetAllBranches());
            }
            catch (Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response =(int)ResponseType.InternalServerError });
            }         

        }

        [HttpGet("getbranchbyid")]
        public async Task<IActionResult> GetBranchById(Guid branchid)
        {
            var result = await _unitOfWork.Branches.GetBranchById(branchid);
            if(result != null) 
            {
                return Ok(result);
            }
            else
            {
                return Ok(new ServiceResponse<Branch>() { Message=MessaageType.UnAuthenticatedRequest, Response =(int)ResponseType.UnAuthenticatedAccess, Success = false });
            }
        }
        [HttpPost("postbranch")]
        public async Task<IActionResult> PostBranch(AddBranchDto addBranchDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    //branchDto.CreatedOn = DateTime.Now;
                    var result = await _unitOfWork.Branches.AddBranch(addBranchDto);
                    await _unitOfWork.Complete();
                    _unitOfWork.Dispose();
                    return Ok(result);
                }
                else
                {
                    return Ok(new ServiceResponse<Branch>() { Message = MessaageType.UnAuthenticatedRequest, Response = (int)ResponseType.UnAuthenticatedAccess, Success = false });

                }

            }
            catch(Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response = (int)ResponseType.InternalServerError });
            }
               
        }
        [HttpPut("putbranch/{id}")]
        public async Task<IActionResult> PutBranch(UpdateBranchDto updateBranchDto,Guid?id)
        {
            try
            {   
                var result = await _unitOfWork.Branches.UpdateBranch(updateBranchDto,id);
                await _unitOfWork.Complete();
                _unitOfWork.Dispose();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response = (int)ResponseType.InternalServerError });
            }
            
        }
        [HttpDelete("deletebranch/{id}")]
        public async Task<IActionResult> DeleteBranch(Guid id)
        {
            try
            {
                var branch = await _dataContext.Branches.Where(x => x.BranchId == id).FirstOrDefaultAsync();
                if (branch != null)
                {
                    branch.IsActive = false;
                    var result = await _unitOfWork.Branches.DeleteBranch(id);
                    await _unitOfWork.Complete();
                    _unitOfWork.Dispose();
                    return Ok(result);
                }
                else
                {
                    return Ok(new ServiceResponse<Branch>() { Message = MessaageType.UnAuthenticatedRequest, Response = (int)ResponseType.UnAuthenticatedAccess, Success = false });
                }
            }
            catch(Exception ex)
            {
                return Ok(new ServiceResponse<Branch>() { Message = MessaageType.FailureOnException, Response = (int)ResponseType.InternalServerError });
            }

        }

    }
}

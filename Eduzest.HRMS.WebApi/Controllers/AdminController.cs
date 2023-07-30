using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Admin;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO;
using Eduzest.HRMS.Repository.DTO.Admin;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduzest.HRMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AdminController> _logger;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public AdminController(DataContext datacontext, IUnitOfWork unitOfWork, IMapper mapper, ILogger<AdminController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _dataContext = datacontext;
        }
        [HttpPost]
        [Route("adminregistration")]
        public async Task<IActionResult> AdminRegistration(RegistrationDto registrationDto)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //branchDto.CreatedOn = DateTime.Now;
                    var result = await _unitOfWork.Admin.AdminRegistration(registrationDto);
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
        [HttpPost]
        [Route("adminlogin")]
        public async Task<IActionResult> AdminLogin(LoginDto loginDto)
        {
            LoginResponse loginResponse = new LoginResponse();
            loginResponse = await _unitOfWork.Admin.AdminLogin(loginDto);

            return Ok(loginResponse);
        }
    }
}

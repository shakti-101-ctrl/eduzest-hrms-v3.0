using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Admin;
using Eduzest.HRMS.Repository.DTO;
using Eduzest.HRMS.Repository.DTO.Admin;
using Eduzest.HRMS.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Service
{
    public class AdminRepository :GenericRepository<Registration>, IAdminRespository

    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AdminRepository(DataContext context, IMapper mapper,IConfiguration configuration) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
           
        }
        public async Task<LoginResponse> AdminLogin(LoginDto loginDto)
        {
            LoginResponse loginResponse = new LoginResponse();
            var userDetails = await _context.Registrations.Where(user=>user.UserId==loginDto.UserId && user.Password==loginDto.Password).FirstOrDefaultAsync();
            if(userDetails!=null)
            {
                var token = GenerateRandomToken(40);
                
                loginResponse.Token = token;
                return loginResponse;
            }
            else
            {
                loginResponse.Token = null;
                return loginResponse;
            }

        }

        public async Task<ServiceResponse<Registration>> AdminRegistration(RegistrationDto registrationDto)
        {
            ServiceResponse<Registration> serviceResponse = new ServiceResponse<Registration>();
            try
            {
                if(registrationDto!=null)
                {
                    registrationDto.CreatedOn = DateTime.Now;
                    this.Add(_mapper.Map<Registration>(registrationDto));
                    //var result = await _unitOfWork.Admin.Add(registrationDto);
                    serviceResponse.Success = true;
                    serviceResponse.Response = (int)ResponseType.Ok;
                    serviceResponse.Message = MessaageType.Saved;

                }
               
            }
            catch (Exception ex)
            {
                serviceResponse.Message = MessaageType.FailureOnException;
                serviceResponse.Success = false;
                serviceResponse.Response = (int)ResponseType.InternalServerError;
            }
            return serviceResponse;
        }

        string GenerateRandomToken(int length)
        {
            string validChars = _configuration["Secret_key"].ToString();
            var random = new RNGCryptoServiceProvider();
            var tokenBytes = new byte[length];
            random.GetBytes(tokenBytes);

            var token = new StringBuilder(length);
            foreach (byte b in tokenBytes)
            {
                token.Append(validChars[b % validChars.Length]);
            }

            return token.ToString();
        }
    }
}

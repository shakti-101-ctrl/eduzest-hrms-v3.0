using Eduzest.HRMS.Entities.Entities.Admin;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO.Admin;
using Eduzest.HRMS.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Interface
{
    public interface IAdminRespository : IGenericRepository<Registration>
    {
        //login funtionality
        public Task<LoginResponse> AdminLogin(LoginDto loginDto);
        public Task<ServiceResponse<Registration>> AdminRegistration(RegistrationDto registrationDto);
    }
}

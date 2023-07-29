using Eduzest.HRMS.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.DTO.Admin
{
    public class RegistrationDto :BaseEntity
    {
        public string? UserId { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        
    }
}

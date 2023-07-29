using Eduzest.HRMS.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Entities.Entities.Admin
{
    public class Registration :BaseEntity
    {
        [Key]
        public string? UserId { get; set; }
        public string? EmailId { get; set;}
        public string? Password { get; set; }
       
    }
}

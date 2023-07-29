using Eduzest.HRMS.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.DTO
{
    public class AddBranchDto
    {
        [JsonIgnore]
        public Guid? BranchId { get; set; }

        //[Required(ErrorMessage ="Branch name is required")]
        public string? BranchName { get; set; }

        //[Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address.")]

        public string? Email { get; set; }

        //[Required(ErrorMessage ="Mobile number is required")]
        public string? MobileNumber { get; set; }

        //[Required(ErrorMessage = "City is required")]
        public string? City { get; set; }

        //[Required(ErrorMessage ="State is required")]
        public string? State { get; set; }

        //[Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public bool IsActive { get; set; }

    }
}

using Eduzest.HRMS.Entities.Entities.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduzest.HRMS.Entities.Base;
using System.Text.Json.Serialization;
using Eduzest.HRMS.Repository.DTO.Employee;

namespace Eduzest.HRMS.Repository.DTO
{
    public class AddDepartmentDto
    {
        [JsonIgnore]
        public Guid? DeptId { get; set; }
        public string? DepartmentName { get; set; }
        public Guid? BranchId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
    public class BranchDto
    {
        public string? branchId { get; set; }
    }

}


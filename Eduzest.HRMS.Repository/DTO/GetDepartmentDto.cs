using Eduzest.HRMS.Entities.Entities.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.DTO
{
    public class GetDepartmentDto
    {
        public Guid? DeptId { get; set; }
        public string? DepartmentName { get; set; }
        public Guid? BranchId { get; set; }
        public string? BranchName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}

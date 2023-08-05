using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.DTO
{
    public class GetDesignationDto
    {
        public Guid Desigid { get; set; }
        public string? Designationname { get; set; }
        public Guid? BranchId { get; set; }
        public string? BranchName { get; set; }
        public Guid? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

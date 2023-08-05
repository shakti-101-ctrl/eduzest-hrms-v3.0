using Eduzest.HRMS.Entities.Entities.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.DTO
{
    public class AddDesignationDto
    {
        [JsonIgnore]
        public Guid Desigid { get; set; }
        public string? Designationname { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? DepartmentId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

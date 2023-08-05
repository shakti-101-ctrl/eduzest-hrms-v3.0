using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.DTO
{
    public class UpdateDesignationDto
    {
        [JsonIgnore]
        public Guid Desigid { get; set; }
        public string? Designationname { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? DepartmentId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

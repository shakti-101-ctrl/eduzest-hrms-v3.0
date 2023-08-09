using Eduzest.HRMS.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Entities.Entities.Employee
{
    //[Table("designation")]
    public class Designation : BaseEntity
    {
        [Key]

        public Guid Desigid { get; set; }
        public string? Designationname { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? DepartmentId { get; set; }
        public virtual Branch? Branch { get; set; }
        public virtual Department? DepartmentDept { get; set; }
        public virtual ICollection<EmployeeDetails> EmployeeDetails { get; set; } = new List<EmployeeDetails>();
    }
}



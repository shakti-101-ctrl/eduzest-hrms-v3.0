using Eduzest.HRMS.Entities.Base;
using Eduzest.HRMS.Entities.Entities.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Entities.Entities.Hrms
{
    //[Table("ExperienceDetails")]
    public class ExperienceDetail : BaseEntity
    {
        [Key]
        [Column("experienceid")]
        public Guid Experienceid { get; set; }
        
        
        [Column("employeeCode"),StringLength(50)]
        public string? EmployeeCode { get; set; }
        
        
        [Column("fromdate")]
        public DateTime? Fromdate { get; set; }
        [Column("todate")]
        public DateTime? Todate { get; set; }
        
        
        [Column("authorizedby"),StringLength(50)]
        public string? Authorizedby { get; set; }
        public virtual EmployeeDetails? EmpCodeEmployeeCodeNavigation { get; set; }

    }
}

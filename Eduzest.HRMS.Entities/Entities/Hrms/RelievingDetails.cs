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
    //[Table("relievingdetails")]
    public class RelievingDetail : BaseEntity
    {
        [Key]
        [Column("relievingid")]
        public Guid Relievingid { get; set; }
        
        [Column("EmployeeCode"),StringLength(100)]
        public string? EmployeeCode { get; set; }
        
        
        [Column("fromdate")]
        public DateTime? Fromdate { get; set; }
        
        [Column("todate")]
        public DateTime? Todate { get; set; }
        [Column("dateofrelease")]
        public DateTime? Dateofrelease { get; set; }

        [Column("authorizedby"),StringLength(50)]
        public string? Authorizedby { get; set; }
        public virtual EmployeeDetails? EmpCodeEmployeeCodeNavigation { get; set; }

    }
}

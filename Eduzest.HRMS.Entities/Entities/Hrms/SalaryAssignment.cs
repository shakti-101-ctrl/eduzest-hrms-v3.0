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
    //[Table("salaryassignment")]
    public class SalaryAssignment : BaseEntity
    {
        [Key]
        [Column("assignid")]
        public Guid Assignid { get; set; }
        
        [Column("employeecode"),StringLength(100)]
        public string? Employeecode { get; set; }
        
        [Column("totalallowance")]
        public float? Totalallowance { get; set; }
        
        [Column("totaldeduction")]
        public float? Totaldeduction { get; set; }
        
        [Column("overtimetotalhour")]
        public int? Overtimetotalhour { get; set; }
        
        [Column("overtimeamount")]
        public float? Overtimeamount { get; set; }
        
        [Column("netsalary")]
        public float? Netsalary { get; set; }
        
        [Column("payvia"),StringLength(50)]
        public string? Payvia { get; set; }
        
        [Column("accountnumber"),StringLength(100)]
        public string? Accountnumber { get; set; }
        
        [Column("remark"),StringLength(100)]
        public string? Remark { get; set; }
        public virtual EmployeeDetails? EmployeecodeNavigation { get; set; }

    }
}
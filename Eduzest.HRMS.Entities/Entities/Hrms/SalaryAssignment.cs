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
        public Guid? AssignId { get; set; }

      
        [ForeignKey("employeecode")]
        public EmployeeDetails? EmployeeCode { get; set; }

        [Column("totalallowance")]
        public float? TotalAllowance { get; set; }

        [Column("totaldeduction")]
        public float? TotalDeduction { get; set; }

        [Column("overtimetotalhour")]
        public int? OverTimeTotalHour { get; set; }

        [Column("overtimeamount")]
        public float? OverTimeAmmount { get; set; }

        [Column("netsalary")]
        public float? NetSalary { get; set; }

        [Column("payvia"),StringLength(50)]
        public string? PayVia { get; set; }

        [Column("accountnumber"), StringLength(50)]
        public string? AccountNumber { get; set; }

        [Column("remark"), StringLength(50)]
        public string? Remark { get; set; }


    }
}
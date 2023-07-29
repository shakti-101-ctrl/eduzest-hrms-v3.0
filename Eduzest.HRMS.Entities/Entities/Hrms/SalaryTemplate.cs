using Eduzest.HRMS.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Entities.Entities.Hrms
{
    //[Table("salarytemplate")]
    public class SalaryTemplate : BaseEntity
    {
        [Key]
        [Column("salarytemplateid")]
        public Guid? SalaryTemplateId { get; set; }

        [Column("salarygrade"),StringLength(50)]
        public string? SalaryGrade { get; set; }

        [Column("basicsalary")]
        public float? BasicSalary { get; set; }

        [Column("overtimerate")]
        public float? OverTimeRate { get; set; }
        
        [Column("totalallowances")]
        public float? TotalAllowances { get; set; }

        [Column("totaldeduction")]
        public float? TotalDeduction { get; set; }

        [Column("netsalary")]
        public float? NetSalary { get; set; }

    }
}





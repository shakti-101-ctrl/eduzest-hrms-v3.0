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
        public Guid Salarytemplateid { get; set; }

        [Column("salarygrade"),StringLength(50)]
        public string? Salarygrade { get; set; }

        [Column("basicsalary")]
        public float? Basicsalary { get; set; }

        [Column("overtimerate")]
        public float? Overtimerate { get; set; }

        [Column("totalallowances")]
        public float? Totalallowances { get; set; }

        [Column("totaldeduction")]
        public float? Totaldeduction { get; set; }

        [Column("netsalary")]
        public float? Netsalary { get; set; }
        public virtual ICollection<Allowances> Allowances { get; set; } = new List<Allowances>();
        public virtual ICollection<Deduction> Deductions { get; set; } = new List<Deduction>();

    }
}





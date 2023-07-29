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
    //[Table("allowances")]
    public class Allowances : BaseEntity
    {
        [Key]
        [Column("allowanceid")]
        public Guid? AllowanceId { get; set; }
        [Column("allowancename"),StringLength(50)]

        public string? AllowanceName { get; set;}

        [Column("ammount")]

        public float? Ammount { get; set; }

        [ForeignKey("salarytemplate")]
        public SalaryTemplate? SalaryTemplate { get; set; }


    }
}

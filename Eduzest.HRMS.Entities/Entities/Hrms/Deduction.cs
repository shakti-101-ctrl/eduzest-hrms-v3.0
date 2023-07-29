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
    //[Table("deduction")]
    public class Deduction : BaseEntity
    {
        [Key]
        [Column("deductionid")]
        public Guid? DeductionId { get; set; }
        [Column("deductionname"), StringLength(50)]

        public string? DeductionName { get; set; }

        [Column("ammount")]

        public float? Ammount { get; set; }

        [ForeignKey("salarytemplateid")]
        public SalaryTemplate? SalaryTemplate { get; set; }
    }
}

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
        public Guid Deductionid { get; set; }
        
        [Column("deductionname"),StringLength(50)]
        public string? Deductionname { get; set; }
        
        [Column("ammount")]
        public float? Ammount { get; set; }
        
        [Column("salarytemplateid")]
        public Guid? Salarytemplateid { get; set; }
        public virtual SalaryTemplate? Salarytemplate { get; set; }
    }
}

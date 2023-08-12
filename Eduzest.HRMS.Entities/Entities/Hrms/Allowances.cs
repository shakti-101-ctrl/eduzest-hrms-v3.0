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
        public Guid Allowanceid { get; set; }
        
        
        [Column("allowancename"),StringLength(50)]
        public string? Allowancename { get; set; }
        
        
        [Column("ammount")]
        public float? Ammount { get; set; }
        
        
        [Column("salarytemplate")]
        public Guid? Salarytemplate { get; set; }
        
        public virtual SalaryTemplate? SalarytemplateNavigation { get; set; }


    }
}

using Eduzest.HRMS.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Entities.Entities.Employee
{
    //[Table("designation")]
    public class Designation : BaseEntity
    {
        [Key]
        [Column("desigid")]
        public Guid? DesigId { get; set; }

        [Column("designationname"),StringLength(50)]
        public string? DesignationName { get; set; }

        [ForeignKey("branchid")]
        public  Branch? Branch { get; set; }
    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Entities.Entities.Log
{
    public class LogDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("message"),StringLength(100)]
        public string? Message { get; set; }

        [Column("stacktrace")]
        [StringLength(200)]
        public string? StackTrace { get; set; }

        [Column("targetsite")]
        [StringLength(200)]
        public string? TargetSite { get; set; }

        [Column("date")]
        [StringLength(200)]
        public DateTime? Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Entities.Base
{
    public class BaseEntity
    {
        
        ////[Column("id")]
        ////[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        ////public Guid? Id { get; set; }
        //[JsonIgnore]

        [Column("createdon"), DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set; }

        [Column("updatedby")]
        public string? UpdatedBy { get; set; }

        [Column("createdby"), StringLength(100)]
        public string? CreatedBy { get; set; }
        [Column("updatedon")]
        public DateTime? UpdatedOn { get; set; }

        [Column("isactive")]
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduzest.HRMS.Entities.Base;

namespace Eduzest.HRMS.Entities.Entities.Employee
{
    
    public class Branch : BaseEntity
    {
        [Key]
        public Guid? BranchId { get; set; }
        [Column("branchname"), StringLength(50)]
        public string? BranchName { get; set; }
        [Column("email"), StringLength(50)]
        public string? Email { get; set; }
        [Column("mobilenumber"), StringLength(10)]
        public string? MobileNumber { get; set; }

        [Column("city"), StringLength(50)]
        public string? City { get; set; }

        [Column("state"), StringLength(50)]
        public string? State { get; set; }

        [Column("address"), StringLength(200)]
        public string? Address { get; set; }

    }
}



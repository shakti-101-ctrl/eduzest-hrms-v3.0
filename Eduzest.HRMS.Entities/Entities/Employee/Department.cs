﻿using Eduzest.HRMS.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Entities.Entities.Employee
{
    //[Table("department")]
    public class Department : BaseEntity
    {
        [Key]
        [Column("deptid")]
        public Guid? DeptId { get; set; }

        [Column("department"),StringLength(50)]
        public string? DepartmentName { get; set; }

        [ForeignKey("fk_branch_department")]
        public Guid? BranchId { get; set; }
        public Branch? Branch { get; set; }

        public virtual ICollection<Designation> Designations { get; set; } = new List<Designation>();
    }
}



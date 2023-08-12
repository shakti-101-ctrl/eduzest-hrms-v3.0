using Eduzest.HRMS.Entities.Base;
using Eduzest.HRMS.Entities.Entities.Enum;
using Eduzest.HRMS.Entities.Entities.Hrms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Entities.Entities.Employee
{
    //[Table("employee")]
    public class EmployeeDetails : BaseEntity
    {
        [Key]
        [Column("employeecode")]
        public string Employeecode { get; set; } = null!;
        
        [Column("branchId")]
        public Guid? BranchId { get; set; }

        [Column("departmentdeptid")]
        public Guid? DepartmentDeptId { get; set; }

        [Column("desigid")]
        public Guid? Desigid { get; set; }

        [Column("qualification"),StringLength(50)]
        public string? Qualification { get; set; }

        [Column("expdetails"), StringLength(50)]
        public string? Expdetails { get; set; }

        public int? Totalexp { get; set; }
        public DateTime? Dateofjoin { get; set; }

        [Column("employeename"), StringLength(50)]
        public string? Employeename { get; set; }

        [Column("fathername"), StringLength(50)]
        public string? Fathername { get; set; }

        [Column("gender"), StringLength(50)]
        public string? Gender { get; set; }

        [Column("religion"), StringLength(50)]
        public string? Religion { get; set; }

        [Column("bloodgroup"), StringLength(50)]
        public string? Bloodgroup { get; set; }

        [Column("dateofbirth")]
        public DateTime? Dateofbirth { get; set; }

        [Column("mobile"), StringLength(50)]
        public string? Mobile { get; set; }

        [Column("email"), StringLength(50)]
        public string? Email { get; set; }

        [Column("presentaddress"), StringLength(200)]
        public string? Presentaddress { get; set; }

        [Column("permanentaddress"), StringLength(200)]
        public string? Permanentaddress { get; set; }

        [Column("profilepicture")]
        public string? Profilepicture { get; set; }

        [Column("username"), StringLength(50)]
        public string? Username { get; set; }

        [Column("password"),StringLength(50)]
        public string? Password { get; set; }

        [Column("facebook"),StringLength(100)]
        public string? Facebook { get; set; }

        [Column("twitter"),StringLength(100)]
        public string? Twitter { get; set; }

        [Column("linkedin"),StringLength(100)]
        public string? Linkedin { get; set; }

        [Column("bankname"),StringLength(50)]
        public string? Bankname { get; set; }

        [Column("bankaddress"),StringLength(200)]
        public string? Bankaddress { get; set; }

        [Column("ifsccode"),StringLength(50)]
        public string? Ifsccode { get; set; }

        [Column("skipbankdetails")]
        public bool? Skipbankdetails { get; set; }
        
        public virtual Branch? Branch { get; set; }
        public virtual Department? DepartmentDept { get; set; }
        public virtual Designation? Desig { get; set; }
        public virtual ICollection<ExperienceDetail> ExperienceDetails { get; set; } = new List<ExperienceDetail>();
        public virtual ICollection<RelievingDetail> RelievingDetails { get; set; } = new List<RelievingDetail>();
        public virtual ICollection<SalaryAssignment> SalaryAssignments { get; set; } = new List<SalaryAssignment>();
    }
}








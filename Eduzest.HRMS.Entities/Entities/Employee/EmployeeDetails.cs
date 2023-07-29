using Eduzest.HRMS.Entities.Base;
using Eduzest.HRMS.Entities.Entities.Enum;
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
        public string? EmployeeCode { get; set; }

        [ForeignKey("branchid")]
       
        public Branch? Brach { get; set; }

        [ForeignKey("deptid")]
       
        public Department? DeptId { get; set; }

        [ForeignKey("desigid")]
       
        public Designation? DesigId { get; set; }

        [Column("qualification"),StringLength(100)]
        public string? Qualification { get; set; }

        [Column("expdetails"), StringLength(100)]
        public string? ExpDetails { get; set; }

        [Column("totalexp")]
        public int? TotalExp { get; set; }

        [Column("dateofjoin")]
        public DateTime? DateOfJoin { get; set; }

        [Column("employeename"), StringLength(50)]
        public string? EmployeeName { get; set; }

        [Column("fathername"), StringLength(50)]
        public string? FatherName { get; set; }

        [Column("gender"), StringLength(50)]
        public Gender? Gender { get; set; }

        [Column("religion"), StringLength(50)]
        public string? Religion { get; set; }

        [Column("bloodgroup"), StringLength(50)]
        public string? BloodGroup { get; set; }

        [Column("dateofbirth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("mobile"), StringLength(50)]
        public string? Mobile { get; set; }

        [Column("email"), StringLength(50)]
        public string? Email { get; set; }

        [Column("presentaddress"), StringLength(200)]
        public string? PresentAddress { get; set; }

        [Column("permanentaddress"), StringLength(200)]
        public string? PermanentAddress { get; set; }

        [Column("profilepicture")]
        public string? profilepicture { get; set; }

        [Column("username"), StringLength(50)]
        public string? UserName { get; set; }

        [Column("password"), StringLength(50)]
        public string? Password { get; set; }

        [Column("facebook"), StringLength(100)]
        public string? FaceBook { get; set; }

        [Column("twitter"), StringLength(100)]
        public string? Twitter { get; set; }

        [Column("linkedin"), StringLength(100)]
        public string? LinkedIn { get; set; }

        [Column("bankname"), StringLength(50)]
        public string? BankName { get; set; }

        [Column("bankaddress"), StringLength(50)]
        public string? BankAddress { get; set; }

        [Column("ifsccode"), StringLength(50)]
        public string? IfscCode { get; set; }

        [Column("skipbankdetails")]
        public bool? SkipBankdetails { get; set; }
    }
}








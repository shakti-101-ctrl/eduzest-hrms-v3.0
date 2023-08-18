using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.DTO
{
    public class GetEmployeeDetailsDto
    {
        public string Employeecode { get; set; } = null!;
        public Guid? BranchId { get; set; }
        public string? BranchName { get;set; }
        public Guid? DepartmentDeptId { get; set; }
        public string? DepartmentName { get; set; }
        public Guid? Desigid { get; set; }
        public string? DesignationName { get;set; }
        public string? Qualification { get; set; }
        public string? Expdetails { get; set; }
        public int? Totalexp { get; set; }
        public DateTime? Dateofjoin { get; set; }
        public string? Employeename { get; set; }
        public string? Fathername { get; set; }
        public string? Gender { get; set; }
        public string? Religion { get; set; }
        public string? Bloodgroup { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Presentaddress { get; set; }
        public string? Permanentaddress { get; set; }
        public string? Profilepicture { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Linkedin { get; set; }
        public string? Bankname { get; set; }
        public string? Bankaddress { get; set; }
        public string? Ifsccode { get; set; }
        public bool? Skipbankdetails { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

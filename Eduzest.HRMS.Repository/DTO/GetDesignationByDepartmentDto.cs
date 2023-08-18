using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.DTO
{
    public class GetDesignationByDepartmentDto
    {

        public Guid? DesignationId { get; set; }
        public string? DesignationName { get; set;}
        public Guid? DepartmentId { get; set; }
        public bool IsActive { get; set; }
    }
}

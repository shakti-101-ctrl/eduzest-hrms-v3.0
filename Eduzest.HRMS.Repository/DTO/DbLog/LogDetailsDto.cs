using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Eduzest.HRMS.Repository.DTO.DbLog
{
    public class LogDetailsDto
    {
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
        public string? TargetSite { get; set; }
        public DateTime? Date { get; set; }
    }
}

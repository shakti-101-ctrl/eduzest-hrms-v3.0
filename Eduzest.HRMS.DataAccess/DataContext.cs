using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Entities.Entities.Hrms;
using Eduzest.HRMS.Entities.Entities.Log;
using Eduzest.HRMS.Entities.Entities.Admin;

namespace Eduzest.HRMS.DataAccess
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Branch>()
            //  .HasMany(b => b.Departments) // One Student has many Addresses
            //  .WithOne(de => de.Branch) // Each Address belongs to one Student
            //  .HasForeignKey(de => de.BranchId);
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<Allowances> Allowances { get; set; }
        public DbSet<Deduction> Deductions { get; set;}
        public DbSet<ExperienceDetail> ExperienceDetails { get; set; }
        public DbSet<RelievingDetail> RelievingDetails { get; set;}
        public DbSet<SalaryAssignment> SalaryAssignments { get; set;}
        public DbSet<SalaryTemplate> SalaryTemplates { get; set;}
        public  DbSet<LogDetails> LogDetails { get; set; }  
        public DbSet<Registration> Registrations { get; set; }

    }
}

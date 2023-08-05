using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Eduzest.HRMS.Repository.Service
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        //private readonly ILogger<BranchRepository> logger;
        private readonly IConfiguration configuration;
        //private readonly UnitOfWorks unitOfWorks;
        public UnitOfWorks(DataContext _context,IMapper _mapper, IConfiguration _configuration)
        {
            this.context = _context;
            this.mapper = _mapper;
            this.configuration = _configuration;
           // this.unitOfWorks = _unitOfWorks;
            
            Branches = new BranchRepository(context,mapper);
            Departments = new DepartmentRepository(context,mapper);
            Admin = new AdminRepository(context, mapper,_configuration);
            Designation= new DesignationRepository(context,mapper);
           
        }
        public IBranchRepository Branches { get; private set; }

        public IAdminRespository Admin { get; private set; }

        public IDepartment Departments { get; private set; }

        public IDesignation Designation { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public Task Complete()
        {
            return context.SaveChangesAsync();
        }
    }
}

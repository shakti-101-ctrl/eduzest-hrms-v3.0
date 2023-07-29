using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Interface
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        //add any other methods if it requires othere than generic methods.
        Task<ServiceResponse<List<GetBranchDto>>> GetAllBranches();
        Task<ServiceResponse<GetBranchDto>> AddBranch(AddBranchDto getBranchDto);
        Task<ServiceResponse<GetBranchDto>> UpdateBranch(UpdateBranchDto updateBranchDto, Guid? id);
        Task<ServiceResponse<GetBranchDto>> DeleteBranch(Guid branchid);
        Task<ServiceResponse<GetBranchDto>> GetBranchById(Guid branchid);
    }
}

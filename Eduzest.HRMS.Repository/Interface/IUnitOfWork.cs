using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IBranchRepository Branches { get; }
        IAdminRespository Admin{ get; }

        Task Complete();
    }
}

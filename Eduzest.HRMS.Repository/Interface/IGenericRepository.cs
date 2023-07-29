using Eduzest.HRMS.Entities.Base;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Service;
using Eduzest.HRMS.Repository.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetItemById(Guid id);
    }
}

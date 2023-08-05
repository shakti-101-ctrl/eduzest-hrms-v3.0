using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Base;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Service
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
       // private readonly ILogger<Gene> _logger;
        public GenericRepository(DataContext context,IMapper mapper)

        {
            _dataContext= context;
            _mapper = mapper;
            //_logger = logger;
                  
        }
        public Task Complete()
        {
            return _dataContext.SaveChangesAsync();
        }
        public void Add(T entity)
        {
            _dataContext.Set<T>().Add(entity);

            //_dataContext.SaveChangesAsync();
        }
        public void Delete(T entity)
        {
          
            _dataContext.Set<T>().Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
            //_dataContext.SaveChangesAsync();
        }


        public T GetById(int id)
        {
            return _dataContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _dataContext.Set<T>().Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
            //_dataContext.SaveChangesAsync();

        }

        public IEnumerable<T> GetAll()
        {
            return _dataContext.Set<T>().ToList();
        }

       
    }
}


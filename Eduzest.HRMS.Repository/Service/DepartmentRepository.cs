using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO;
using Eduzest.HRMS.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Service
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartment
    {

        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public DepartmentRepository(DataContext _dataContext, IMapper _mapper) : base(_dataContext, _mapper)
        {
            this.dataContext = _dataContext;
            this.mapper = _mapper;


        }
        public async Task<ServiceResponse<GetDepartmentDto>> AddDepartments(AddDepartmentDto addDepartmentDto)
        {
            ServiceResponse<GetDepartmentDto> serviceResponse = new ServiceResponse<GetDepartmentDto>();
            try
            {
                if (dataContext != null)
                {
                    addDepartmentDto.DeptId = Guid.NewGuid();
                    addDepartmentDto.CreatedOn = DateTime.Now;
                   
                    this.Add(mapper.Map<Department>(addDepartmentDto));
                    //await dataContext.SaveChangesAsync();
                    //var test =await dataContext.Branches.OrderBy(e => e.CreatedOn).LastOrDefaultAsync();
                    //serviceResponse.Data = mapper.Map<GetBranchDto>(await dataContext.Branches.OrderBy(e=>e.CreatedOn).LastOrDefaultAsync());
                    serviceResponse.Success = true;
                    serviceResponse.Response = (int)ResponseType.Ok;
                    serviceResponse.Message = MessaageType.Saved;
                }
                else
                {
                    serviceResponse.Message = MessaageType.FailureOnSave;
                    serviceResponse.Success = true;
                    serviceResponse.Response = (int)ResponseType.NoConnect;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Response = (int)ResponseType.InternalServerError;
                serviceResponse.Message = MessaageType.FailureOnException;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDepartmentDto>> DeleteDepartment(Guid deptId)
        {
            ServiceResponse<GetDepartmentDto> serviceResponse = new ServiceResponse<GetDepartmentDto>();

            try
            {
                if (dataContext != null)
                {
                    Department department = await dataContext.Departments.FindAsync(deptId);
                    if (department != null)
                    {
                        department.IsActive = false;
                        this.Delete(department);
                        serviceResponse.Data = mapper.Map<GetDepartmentDto>(department);
                        serviceResponse.Message = MessaageType.Deleted;
                        serviceResponse.Success = true;
                        serviceResponse.Response = (int)ResponseType.Ok;
                    }
                    else
                    {
                        serviceResponse.Message = MessaageType.DeletionFailed;
                        serviceResponse.Success = false;
                        serviceResponse.Response = (int)ResponseType.NoConnect;
                    }
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Message = MessaageType.FailureOnException;
                serviceResponse.Success = false;
                serviceResponse.Response = (int)ResponseType.InternalServerError;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDepartmentDto>>> GetAllDepartments()
        {
            ServiceResponse<List<GetDepartmentDto>> serviceResponse = new ServiceResponse<List<GetDepartmentDto>>();
            try
            {
                var departments =await(from branch in dataContext.Branches
                                        join department in dataContext.Departments on branch.BranchId equals department.BranchId
                                       select new GetDepartmentDto
                                       {
                                           DeptId = department.DeptId,
                                           BranchId = branch.BranchId,
                                           BranchName = branch.BranchName,
                                           DepartmentName = department.DepartmentName,
                                           IsActive = department.IsActive,
                                           CreatedOn = department.CreatedOn,
                                           CreatedBy = department.CreatedBy,
                                           UpdatedOn = department.UpdatedOn
                                       }).OrderByDescending(s=>s.CreatedOn).Where(d=>d.IsActive==true).ToListAsync();

                if(departments.Count>0)
                {
                    serviceResponse.Data = departments;
                    serviceResponse.Message = MessaageType.RecordFound;
                    serviceResponse.Response = (int)ResponseType.Ok;
                    serviceResponse.Success = true;
                }
                else
                {
                    serviceResponse.Message = MessaageType.NoRecordFound;
                    serviceResponse.Response = (int)ResponseType.NoConnect;
                    serviceResponse.Success = false;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Response = (int)ResponseType.InternalServerError;
                serviceResponse.Message = MessaageType.FailureOnException;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDepartmentDto>> GetDepartmentById(Guid deptid)
        {
            ServiceResponse<GetDepartmentDto> serviceResponse = new ServiceResponse<GetDepartmentDto>();
            var department = this.GetDepartmentById(deptid);
            if (department != null)
            {
                serviceResponse.Data = mapper.Map<GetDepartmentDto>(department);
                serviceResponse.Message = MessaageType.RecordFound;
                serviceResponse.Response = (int)ResponseType.Ok;
                serviceResponse.Success = true;

            }
            else
            {
                serviceResponse.Message = MessaageType.NoRecordFound;
                serviceResponse.Response = (int)ResponseType.NoConnect;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDepartmentDto>> UpdateDepartments(UpdateDepartmentDto updateDepartmentDto, Guid? id)
        {
            ServiceResponse<GetDepartmentDto> serviceResponse = new ServiceResponse<GetDepartmentDto>();
            try
            {
                if (dataContext != null)
                {
                    Department department = await dataContext.Departments.FindAsync(id);
                    if (department != null)
                    {

                        department.DepartmentName =updateDepartmentDto.DepartmentName;
                        department.BranchId = updateDepartmentDto.BranchId;
                        department.UpdatedOn = DateTime.Now;
                        department.UpdatedBy = updateDepartmentDto.UpdatedBy;
                        this.Update(mapper.Map<Department>(department));
                        //await dataContext.SaveChangesAsync();
                        serviceResponse.Data = mapper.Map<GetDepartmentDto>(department);
                        serviceResponse.Message = MessaageType.Updated;
                        serviceResponse.Success = true;
                        serviceResponse.Response = (int)ResponseType.Ok;

                    }
                    else
                    {
                        serviceResponse.Message = MessaageType.FailureOnUpdate;
                        serviceResponse.Success = false;
                        serviceResponse.Response = (int)ResponseType.UnAuthenticatedAccess;
                    }

                }
                else
                {
                    serviceResponse.Message = MessaageType.FailureOnUpdate;
                    serviceResponse.Success = false;
                    serviceResponse.Response = (int)ResponseType.NoConnect;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Response = (int)ResponseType.InternalServerError;
                serviceResponse.Message = MessaageType.FailureOnException;
            }
            return serviceResponse;
        }
    }
}

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
    public class DesignationRepository : GenericRepository<Designation>, IDesignation
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public DesignationRepository(DataContext _dataContext, IMapper _mapper) : base(_dataContext, _mapper)
        {
            this.dataContext = _dataContext;
            this.mapper = _mapper;
        }
        public async Task<ServiceResponse<GetDesignationDto>> AddDesignation(AddDesignationDto addDesignationDto)
        {
            ServiceResponse<GetDesignationDto> serviceResponse = new ServiceResponse<GetDesignationDto>();
            try
            {
                if (dataContext != null)
                {
                    addDesignationDto.Desigid = Guid.NewGuid();
                    addDesignationDto.CreatedOn = DateTime.Now;
                    this.Add(mapper.Map<Designation>(addDesignationDto));
                    await this.Complete();
                    //serviceResponse.Data =mapper.Map<GetDesignationDto>(dataContext.Designations.OrderBy(x => x.CreatedOn).LastOrDefaultAsync());
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

        public async Task<ServiceResponse<GetDesignationDto>> DeleteDesignation(Guid designationId)
        {
            ServiceResponse<GetDesignationDto> serviceResponse = new ServiceResponse<GetDesignationDto>();

            try
            {
                if (dataContext != null)
                {
                    Designation designation = await dataContext.Designations.FindAsync(designationId);
                    if (designation != null)
                    {
                        designation.IsActive = false;

                        this.Delete(designation);
                        await this.Complete();
                        serviceResponse.Data = mapper.Map<GetDesignationDto>(designation);
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

        public async Task<ServiceResponse<List<GetDesignationDto>>> GetAllDesignation()
        {
            ServiceResponse<List<GetDesignationDto>> serviceResponse = new ServiceResponse<List<GetDesignationDto>>();
            try
            {
                var designations = await (from _branch in dataContext.Branches
                                          join _dept in dataContext.Departments on _branch.BranchId equals _dept.BranchId
                                          join _desig in dataContext.Designations on _dept.DeptId equals _desig.DepartmentId
                                          select new GetDesignationDto
                                          {
                                              Desigid = _desig.Desigid,
                                              Designationname= _desig.Designationname,
                                              BranchId = _dept.BranchId,
                                              BranchName=_branch.BranchName,
                                              DepartmentId=_desig.DepartmentId,
                                              DepartmentName=_dept.DepartmentName,
                                              CreatedOn=_desig.CreatedOn,
                                              CreatedBy=_desig.CreatedBy,
                                              UpdatedOn=_desig.UpdatedOn,
                                              UpdatedBy=_desig.UpdatedBy,
                                              IsActive= _desig.IsActive


                                          }).OrderByDescending(d => d.CreatedOn).Where(d=>d.IsActive).ToListAsync();
               if(designations.Count>0)
                {
                    serviceResponse.Data = designations;
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
            catch(Exception ex) 
            {
                serviceResponse.Success = false;
                serviceResponse.Response = (int)ResponseType.InternalServerError;
                serviceResponse.Message = MessaageType.FailureOnException;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDesignationDto>> GetDesignationById(Guid designationId)
        {
            ServiceResponse<GetDesignationDto> serviceResponse = new ServiceResponse<GetDesignationDto>();
            var designation = this.GetDesignationById(designationId);
            if (designation != null)
            {
                serviceResponse.Data = mapper.Map<GetDesignationDto>(designation);
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

        public async Task<ServiceResponse<GetDesignationDto>> UpdateDesignation(UpdateDesignationDto updateDesignationDto, Guid? id)
        {
            ServiceResponse<GetDesignationDto> serviceResponse = new ServiceResponse<GetDesignationDto>();
            try
            {
                if (dataContext != null)
                {
                    Designation designation = await dataContext.Designations.FindAsync(id);
                    if (designation != null)
                    {
                       designation.Designationname = updateDesignationDto.Designationname;
                        designation.BranchId = updateDesignationDto.BranchId;
                        designation.DepartmentId = updateDesignationDto.DepartmentId;
                        designation.UpdatedOn = updateDesignationDto.UpdatedOn;
                        designation.UpdatedBy = updateDesignationDto.UpdatedBy;
                        this.Update(mapper.Map<Designation>(designation));
                        await this.Complete();
                        serviceResponse.Data = mapper.Map<GetDesignationDto>(designation);
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

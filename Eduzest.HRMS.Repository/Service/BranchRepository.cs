using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Diagnostics;
using Serilog.Core;
using System.Linq.Expressions;
using Eduzest.HRMS.Repository.DTO;

namespace Eduzest.HRMS.Repository.Service
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public BranchRepository(DataContext _dataContext, IMapper _mapper) : base(_dataContext, _mapper)
        {
            this.dataContext = _dataContext;
            this.mapper = _mapper;
            

        }
        public async Task<ServiceResponse<GetBranchDto>> AddBranch(AddBranchDto addBranchDto)
        {
            ServiceResponse<GetBranchDto> serviceResponse = new ServiceResponse<GetBranchDto>();
            try
            {
                if (dataContext != null)
                {
                    addBranchDto.BranchId = Guid.NewGuid();
                    addBranchDto.CreatedOn = DateTime.Now;
                    this.Add(mapper.Map<Branch>(addBranchDto));

                    //var test =await dataContext.Branches.OrderBy(e => e.CreatedOn).LastOrDefaultAsync();
                    serviceResponse.Data = mapper.Map<GetBranchDto>(await dataContext.Branches.OrderBy(e=>e.CreatedOn).LastOrDefaultAsync());
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

        public async Task<ServiceResponse<GetBranchDto>> DeleteBranch(Guid branchid)
        {
            ServiceResponse<GetBranchDto> serviceResponse = new ServiceResponse<GetBranchDto>();
            Branch branch = await dataContext.Branches.FindAsync(branchid);
            try
            {
                if (branch != null)
                {
                    branch.IsActive = false;
                    this.Delete(branch);
                    serviceResponse.Data = mapper.Map<GetBranchDto>(branch);
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
            catch (Exception ex)
            {
                serviceResponse.Message = MessaageType.FailureOnException;
                serviceResponse.Success = false;
                serviceResponse.Response = (int)ResponseType.InternalServerError;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBranchDto>> GetBranchById(Guid branchid)
        {
            ServiceResponse<GetBranchDto> serviceResponse = new ServiceResponse<GetBranchDto>();
            var branch = this.GetItemById(branchid);
            if (branch != null)
            {
                serviceResponse.Data = mapper.Map<GetBranchDto>(branch);
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

        public async Task<ServiceResponse<List<GetBranchDto>>> GetAllBranches()
        {
            ServiceResponse<List<GetBranchDto>> serviceResponse = new ServiceResponse<List<GetBranchDto>>();
            try
            {

                var branches = await this.GetAll();
                if (branches.Count > 0)
                {

                    serviceResponse.Data = mapper.Map<List<GetBranchDto>>(branches.Where(x=>x.IsActive==true));
                    serviceResponse.Message = MessaageType.RecordFound;
                    serviceResponse.Response = (int)ResponseType.Ok;
                    serviceResponse.Success = true;
                }
                else
                {
                    //serviceResponse.data = _mapper.Map<List<GetCategoryDto>>(category);
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

        public async Task<ServiceResponse<GetBranchDto>> UpdateBranch(UpdateBranchDto updateBranchDto, Guid? id)
        {
            ServiceResponse<GetBranchDto> serviceResponse = new ServiceResponse<GetBranchDto>();
            try
            {
                if (dataContext != null)
                {
                    Branch brachDetails = await dataContext.Branches.FindAsync(id);
                    if (brachDetails != null)
                    {
                        brachDetails.BranchName = updateBranchDto.BranchName;
                        brachDetails.City = updateBranchDto.City;
                        brachDetails.State = updateBranchDto.State;
                        brachDetails.Email = updateBranchDto.Email;
                        brachDetails.MobileNumber = updateBranchDto.MobileNumber;
                        brachDetails.Address = updateBranchDto.Address;
                        brachDetails.UpdatedOn = DateTime.Now;
                        brachDetails.UpdatedBy = updateBranchDto.UpdatedBy;
                        this.Update(mapper.Map<Branch>(brachDetails));
                        serviceResponse.Data = mapper.Map<GetBranchDto>(brachDetails);
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

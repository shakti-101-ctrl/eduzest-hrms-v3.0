using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO;
using Eduzest.HRMS.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Service
{
    public class EmployeeRepository : GenericRepository<EmployeeDetails>, IEmployeeDetails
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public EmployeeRepository(DataContext _dataContext, IMapper _mapper) : base(_dataContext, _mapper)
        {
            this.dataContext = _dataContext;
            this.mapper = _mapper;


        }
        public async Task<ServiceResponse<GetEmployeeDetailsDto>> AddEmployeeDetails(AddEmployeeDetailsDto employeeDetailsDto)
        {
            ServiceResponse<GetEmployeeDetailsDto> serviceResponse = new ServiceResponse<GetEmployeeDetailsDto>();
            try
            {
                if (dataContext != null)
                {
                    //employeeDetailsDto.Employeecode = Guid.NewGuid();
                    employeeDetailsDto.CreatedOn = DateTime.Now;

                    this.Add(mapper.Map<EmployeeDetails>(employeeDetailsDto));
                    await this.Complete();
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

        public async Task<ServiceResponse<GetEmployeeDetailsDto>> DeleteEmployeeDetails(string employeecode)
        {
            ServiceResponse<GetEmployeeDetailsDto> serviceResponse = new ServiceResponse<GetEmployeeDetailsDto>();

            try
            {
                if (dataContext != null)
                {
                    EmployeeDetails employeeDetails = await dataContext.EmployeeDetails.FindAsync(employeecode);
                    if (employeeDetails != null)
                    {
                        employeeDetails.IsActive = false;

                        this.Delete(employeeDetails);
                        await this.Complete();
                        serviceResponse.Data = mapper.Map<GetEmployeeDetailsDto>(employeeDetails);
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

        public async Task<ServiceResponse<List<GetEmployeeDetailsDto>>> GetAllEmployee()
        {
            ServiceResponse<List<GetEmployeeDetailsDto>> serviceResponse = new ServiceResponse<List<GetEmployeeDetailsDto>>();
            try
            {
                var employeeDeytails = await(from empDetails in dataContext.EmployeeDetails
                                             join branch in dataContext.Branches on empDetails.BranchId equals branch.BranchId
                                             join department in dataContext.Departments on empDetails.DepartmentDeptId equals department.DeptId
                                             join designation in dataContext.Designations on empDetails.Desigid equals designation.Desigid
                                             select new GetEmployeeDetailsDto
                                             {
                                                 Employeecode = empDetails.Employeecode,
                                                 BranchId = empDetails.BranchId,
                                                 BranchName = branch.BranchName,
                                                 DepartmentDeptId = empDetails.DepartmentDeptId,
                                                 DepartmentName = department.DepartmentName,
                                                 Desigid = empDetails.Desigid,
                                                 DesignationName = designation.Designationname,
                                                 Qualification = empDetails.Qualification,
                                                 Expdetails = empDetails.Expdetails,
                                                 Totalexp = empDetails.Totalexp,
                                                 Dateofjoin = empDetails.Dateofjoin,
                                                 Employeename = empDetails.Employeename,
                                                 Fathername = empDetails.Fathername,
                                                 Gender = empDetails.Gender,
                                                 Religion = empDetails.Religion,
                                                 Bloodgroup = empDetails.Bloodgroup,
                                                 Dateofbirth = empDetails.Dateofbirth,
                                                 Mobile = empDetails.Mobile,
                                                 Email = empDetails.Email,
                                                 Presentaddress = empDetails.Presentaddress,
                                                 Permanentaddress = empDetails.Permanentaddress,
                                                 Profilepicture = empDetails.Profilepicture,
                                                 Username = empDetails.Username,
                                                 Password = empDetails.Password,
                                                 Facebook = empDetails.Facebook,
                                                 Twitter = empDetails.Twitter,
                                                 Linkedin = empDetails.Linkedin,
                                                 Bankname = empDetails.Bankname,
                                                 Bankaddress = empDetails.Bankaddress,
                                                 Ifsccode = empDetails.Ifsccode,
                                                 Skipbankdetails = empDetails.Skipbankdetails,
                                                 CreatedOn = empDetails.CreatedOn,
                                                 UpdatedBy = empDetails.UpdatedBy,
                                                 CreatedBy = empDetails.CreatedBy,
                                                 UpdatedOn = empDetails.UpdatedOn,
                                                 IsActive = empDetails.IsActive

                                             }).OrderByDescending(e => e.CreatedOn).Where(e => e.IsActive).ToListAsync();
                if (employeeDeytails.Count > 0)
                {
                    serviceResponse.Data = employeeDeytails;
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

        public async Task<ServiceResponse<GetEmployeeDetailsDto>> GetEmployeeByEmpCode(string empcode)
        {
            ServiceResponse<GetEmployeeDetailsDto> serviceResponse = new ServiceResponse<GetEmployeeDetailsDto>();
            var employee = this.GetEmployeeByEmpCode(empcode);
            if (employee != null)
            {
                serviceResponse.Data = mapper.Map<GetEmployeeDetailsDto>(employee);
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

        public async Task<ServiceResponse<GetEmployeeDetailsDto>> UpdateEmployeeDetails(UpdateEmployeeDetailsDto updateEmployeeDetailsDto, string id)
        {
            ServiceResponse<GetEmployeeDetailsDto> serviceResponse = new ServiceResponse<GetEmployeeDetailsDto>();
            try
            {
                if (dataContext != null)
                {
                    EmployeeDetails employee = await dataContext.EmployeeDetails.FindAsync(id);
                    if (employee != null)
                    {
                        employee.BranchId=updateEmployeeDetailsDto.BranchId;
                        employee.DepartmentDeptId = updateEmployeeDetailsDto.DepartmentDeptId;
                        employee.Desigid = updateEmployeeDetailsDto.Desigid;
                        employee.Qualification=updateEmployeeDetailsDto.Qualification;
                        employee.Expdetails=updateEmployeeDetailsDto.Expdetails;
                        employee.Totalexp=updateEmployeeDetailsDto.Totalexp;
                        employee.Dateofjoin=updateEmployeeDetailsDto.Dateofjoin;
                        employee.Employeename = updateEmployeeDetailsDto.Employeename;
                        employee.Fathername=updateEmployeeDetailsDto.Fathername;
                        employee.Gender = updateEmployeeDetailsDto.Gender;
                        employee.Religion=updateEmployeeDetailsDto.Religion;
                        employee.Bloodgroup=updateEmployeeDetailsDto.Bloodgroup;
                        employee.Dateofbirth = updateEmployeeDetailsDto.Dateofbirth;
                        employee.Mobile = updateEmployeeDetailsDto.Mobile;
                        employee.Email=updateEmployeeDetailsDto.Email;
                        employee.Presentaddress=updateEmployeeDetailsDto.Presentaddress;
                        employee.Permanentaddress = updateEmployeeDetailsDto.Permanentaddress;
                        employee.Profilepicture=updateEmployeeDetailsDto.Profilepicture;
                        employee.Username=updateEmployeeDetailsDto.Username;
                        employee.Password=updateEmployeeDetailsDto.Password;
                        employee.Facebook=updateEmployeeDetailsDto.Facebook;
                        employee.Twitter=updateEmployeeDetailsDto.Twitter;
                        employee.Linkedin=updateEmployeeDetailsDto.Linkedin;
                        employee.Bankname=updateEmployeeDetailsDto.Bankname;
                        employee.Bankaddress=updateEmployeeDetailsDto.Bankaddress;
                        employee.Ifsccode=updateEmployeeDetailsDto.Ifsccode;
                        employee.Skipbankdetails=updateEmployeeDetailsDto.Skipbankdetails;
                        employee.UpdatedBy = updateEmployeeDetailsDto.UpdatedBy;
                        employee.UpdatedOn=updateEmployeeDetailsDto.UpdatedOn;
                        this.Update(mapper.Map<EmployeeDetails>(employee));
                        await this.Complete();
                        serviceResponse.Data = mapper.Map<GetEmployeeDetailsDto>(employee);
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

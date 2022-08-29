using HotelManagement.Aspects.Autofac.Caching;
using HotelManagement.Bll.EntityCore.Abstract.Employees;
using HotelManagement.Bll.Helpers;
using HotelManagement.Bll.ValidationRule.FluentValidation.Employees;
using HotelManagement.Core.Aspects.Autofac.Validation;
using HotelManagement.Core.Helpers.Attributes;
using HotelManagement.Core.Utilities.Results.Abstract;
using HotelManagement.Core.Utilities.Results.Concrete;
using HotelManagement.Dal.EfCore;
using HotelManagement.Dal.EfCore.Concrete;
using HotelManagement.Dto.Employees;
using HotelManagement.Entity.Shared;
using HotelManagement_Entity.Models.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.Bll.EntityCore.Concrete.Employees
{
    public class EmployeeRepository : EntityBaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HotelManagementContext context) : base(context)
        {
        }

        /// <summary>
        /// Yeni çalışan kaydı oluşturur.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [ValidationAspect(typeof(EmployeeValidator))]
        [CacheRemoveAspect("IEmployeeRepository.Get")]
        public IResult AddEmployee(Employee employee)
        {
            if (FindBy(x => x.DataStatus == DataStatus.Activated && x.UserId == employee.UserId).Any())
                return new ErrorResult("Seçilen kullanıcı zaten bir personele tanımlanmış!");


            Random rastgele = new Random();
            int sayi = rastgele.Next(0, 1000);
            employee.EmployeeCode = employee.Name.Substring(0, 2).ToUpper() + employee.Surname.Substring(0, 2).ToUpper() + (sayi + 1).ToString();



            try
            {
                Add(employee);
                Commit();
                return new SuccessResult(SystemConstants.AddedMessage);
            }
            catch (Exception e)
            {
                return new ErrorResult(SystemConstants.AddedErrorMessage);
            }
        }

        /// <summary>
        /// Çalışan kaydını siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IEmployeeRepository.Get")]
        public IResult DeleteEmployee(int id)
        {
            var result = FindBy(a => a.Id == id).FirstOrDefault();
            if (result == null)
                return new ErrorResult(SystemConstants.NoData);

            else
            {
                try
                {
                    Delete(result);
                    Commit();
                    return new SuccessResult(SystemConstants.DeletedMessage);
                }
                catch (Exception)
                {
                    return new ErrorResult(SystemConstants.DeletedErrorMessage);
                }
            }
        }

        /// <summary>
        /// Aktif olan tüm çalışanları getirir.
        /// </summary>
        /// <returns></returns>
        [CacheAspect(duration: 10)]
        public IDataResult<IQueryable<Employee>> GetAllEmployee()
        {
            var result = FindBy(m => m.DataStatus == DataStatus.Activated);
            return new SuccessDataResult<IQueryable<Employee>>(result);
        }

        /// <summary>
        /// Tüm personelleri gride basmak amacıyla detay bilgileri ile birlikte döndürür.
        /// </summary>
        /// <returns></returns>
        [CacheAspect(duration: 10)]
        public IDataResult<IQueryable<EmployeeDto>> GetAllEmployeeDetailTable()
        {
            var employeeList = FindBy(m => m.DataStatus == DataStatus.Activated)
                               .Select(s => new EmployeeDto
                               {
                                   Id = s.Id,
                                   Email = s.Email,
                                   EmployeeCode = s.EmployeeCode,
                                   FullName = s.Name + " " + s.Surname,
                                   JobStartDate = s.JobStartDate,
                                   PhoneNumber = s.PhoneNumber,
                                   UserId = s.UserId
                               })
                               .AsNoTracking();
            return new SuccessDataResult<IQueryable<EmployeeDto>>(employeeList);
        }

        /// <summary>
        /// Tekil biglisine göre çalışan getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [CacheAspect(duration: 10)]
        public IDataResult<Employee> GetById(int id)
        {
            var result = FindBy(m => m.DataStatus == DataStatus.Activated &&
                                    m.Id == id)
                        .FirstOrDefault();

            if (result != null)
                return new SuccessDataResult<Employee>(result);
            else
                return new ErrorDataResult<Employee>(null, SystemConstants.NoData);
        }


        /// <summary>
        /// Çalışan güncellemesi yapar
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [ValidationAspect(typeof(EmployeeValidator))]
        [CacheRemoveAspect("IEmployeeRepository.Get")]
        public IResult UpdateEmployee(Employee employee)
        {
            var hasData = FindBy(m => m.DataStatus == DataStatus.Activated &&
                                      m.Id == employee.Id)
                          .FirstOrDefault();
            if (hasData == null)
                return new ErrorDataResult<Employee>(null, SystemConstants.NoData);

            try
            {
                hasData.Name = employee.Name;
                hasData.Surname = employee.Surname;
                hasData.PhoneNumber = employee.PhoneNumber;
                hasData.Email = employee.Email;
                hasData.JobStartDate = employee.JobStartDate;
                Update(hasData);
                Commit();

                return new SuccessResult(SystemConstants.UpdatedMessage);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Employee>(null, SystemConstants.UpdatedErrorMessage);
            }
        }
    }
}

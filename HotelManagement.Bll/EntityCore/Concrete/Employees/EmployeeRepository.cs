using HotelManagement.Aspects.Autofac.Caching;
using HotelManagement.Bll.EntityCore.Abstract.Employees;
using HotelManagement.Bll.Helpers;
using HotelManagement.Bll.ValidationRule.FluentValidation.Employees;
using HotelManagement.Core.Aspects.Autofac.Validation;
using HotelManagement.Core.Utilities.Results.Abstract;
using HotelManagement.Core.Utilities.Results.Concrete;
using HotelManagement.Dal.EfCore;
using HotelManagement.Dal.EfCore.Concrete;
using HotelManagement.Entity.Shared;
using HotelManagement_Entity.Models.Employees;
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

            employee.EmployeeCode = Guid.NewGuid().ToString().Substring(0,5);
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
                hasData.EmployeeType = employee.EmployeeType;
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

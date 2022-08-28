using HotelManagement.Core.Utilities.Results.Abstract;
using HotelManagement.Dal.EfCore.Abstract;
using HotelManagement.Dto.Employees;
using HotelManagement_Entity.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.Bll.EntityCore.Abstract.Employees
{
    public interface IEmployeeRepository : IEntityBaseRepository<Employee>
    {
        IDataResult<IQueryable<Employee>> GetAllEmployee();

        IDataResult<Employee> GetById(int id);

        IResult AddEmployee(Employee employee);

        IResult UpdateEmployee(Employee employee);

        IResult DeleteEmployee(int id);

        IDataResult<IQueryable<EmployeeDto>> GetAllEmployeeDetailTable();
    }
}

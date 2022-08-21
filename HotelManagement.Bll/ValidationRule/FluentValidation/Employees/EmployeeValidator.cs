using FluentValidation;
using HotelManagement_Entity.Models.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Bll.ValidationRule.FluentValidation.Employees
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Surname).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.EmployeeType).NotEmpty();
            RuleFor(p => p.JobStartDate).NotEmpty();
        }
    }
}

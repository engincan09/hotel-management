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
            RuleFor(p => p.Name).NotEmpty().WithMessage("Lütfen çalışan adını boş geçmeyiniz.");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Lütfen çalışan soyadını boş geçmeyiniz.");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("Lütfen çalışan telefonunu boş geçmeyiniz.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Lütfen çalışan mail adresini boş geçmeyiniz.");
            RuleFor(p => p.JobStartDate).NotEmpty().WithMessage("Lütfen çalışanın işe başlangıç tarihini boş geçmeyiniz.");
        }
    }
}

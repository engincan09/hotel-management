using FluentValidation;
using HotelManagement.Entity.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Bll.ValidationRule.FluentValidation.Users
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Surname).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
        }
    }
}

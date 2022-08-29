using FluentValidation;
using HotelManagement_Entity.Models.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Bll.ValidationRule.FluentValidation.Systems
{

    public class OrganizasyonValidator : AbstractValidator<Organizasyon>
    {
        public OrganizasyonValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Lütfen organizasyon adını boş geçmeyiniz.");
            RuleFor(p => p.NumberOfStaff).NotEmpty().WithMessage("Lütfen kadro sayısını boş geçmeyiniz");
        }
    }
}

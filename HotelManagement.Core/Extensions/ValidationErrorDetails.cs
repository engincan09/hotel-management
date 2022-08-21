using FluentValidation.Results;
using ReCapProjectCore.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Extensions
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}

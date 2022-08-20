using System;
using System.Collections.Generic;
using System.Text;
using HotelManagement.Core.Utilities.Results.Abstract;

namespace HotelManagement.Core.Utilities.Results.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}

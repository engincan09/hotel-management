using System;
using System.Collections.Generic;
using System.Text;
using HotelManagement.Core.Utilities.Results.Abstract;

namespace HotelManagement.Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string messages) : base(success, messages)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}

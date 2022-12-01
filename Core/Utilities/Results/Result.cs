using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public Result(bool success, string message) : this(success)
        {
            //read-only olmasına rağmen constructorda sett edilebilir!!!!
            this.Message = message;
        }
        public Result(bool success)
        {
            //Consturctor overloading
            this.Success = success;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message ):this(success)  //iki parametre verirsen aşağıdakni de çalıştırısın. tek parametre verirsen zaten sadece aşağıdaki çalışır.
        {
            Message = message;

            
        }

        public Result(bool success)
        {
            
            Success = success;

        }

        public bool Success { get; }

        public string Message { get; }
    }
}

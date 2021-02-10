using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç 
    public  interface IResult
    {
        bool Success { get; } //constructorla set edebiliriz
        string Message { get; } //get okuma sadece return ettirilebilir

    }
}

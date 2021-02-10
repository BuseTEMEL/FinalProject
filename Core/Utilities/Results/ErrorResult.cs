using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message) //base e bir şey göndermek istiyorsam :base() yaparım. 
        {

        }

        public ErrorResult() : base(false)
        {

        }
    }
}

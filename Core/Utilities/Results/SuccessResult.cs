using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message):base(true,message) //base e bir şey göndermek istiyorsam :base yaparım. 
        {

        }

        public SuccessResult():base(true)
        {

        }
            
    }
}

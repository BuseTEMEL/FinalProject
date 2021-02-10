using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> :IResult  //sen zaten ressultsın yani success ve message çeriyorsun ekstra
    {
        T Data { get; }  //bana bir tipte data ver 
    }
}

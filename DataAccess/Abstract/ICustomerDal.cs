using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess
{ 
    public interface ICustomerDal: IEntityRepository<Customer>
    {
    }
}

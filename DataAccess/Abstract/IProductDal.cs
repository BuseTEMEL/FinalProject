using Core.DataAccess;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess
{
    public interface IProductDal : IEntityRepository<Product>  
    {
        public List<ProductDetailDto> GetProductDetails();


    }
}

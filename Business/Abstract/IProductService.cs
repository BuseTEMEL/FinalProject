using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();  // ürünlerin hepsini getiriyoruz.  //MESAJ İŞLEM SONUCU VE DATA İÇERSİN YANİ RESULT ADINA EK OLARAK DATA EKLEDİM
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);  // product türünden yani sadece ürün tipinde gelecek bana

         IResult Add(Product product);
    }
}

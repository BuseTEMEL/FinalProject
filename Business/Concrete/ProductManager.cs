using Business.Abstract;
using Business.Constants;
using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;    //constructor injection
        //IProductDal InMemoryProductDal ın içindekileri tutuyor. yani referansını tutuyor. ve biz zaten InMemoryProductDal da constructor çalıştırıyoruz.
        //O constructor daki ürün verilerini buraya enjekte ettik. ürünün bilgileri olmadan çağıramayız çünkü.

        //ctor
        public ProductManager(IProductDal productDal) //IProductDal içindeki ürünlerin her biri artık 'productDal'
        {
            _productDal = productDal; //burada enjekte ediyorum. IProductDal a _productDal takma adını veriyorum bu class için
            //ve productDal daki her bir ürünün bilgisini _productDal a atıyorum.
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour ==22)   //HER GÜN 22 DE ÜRÜNLERİN LİSTELENMESİNİ KAPATMAK İSTİYORUM.
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new  SuccessDataResult<List<Product>> (_productDal.GetAll(),Messages.ProductsListed); 
            // data result dönderiyorum dönderdiğim tip list  dönderdiğim data _productDal.GetAll ile geliyor zaten. ekstradan işlem sonucum ve mesajım var. 
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p=> p.UnitPrice>= min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails());
        }
        public IResult Add(Product product)
        {
            //business codes
            if (product.ProductName.Length<2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product> (_productDal.Get(p=>p.ProductId ==productId));        
        }
    }
}

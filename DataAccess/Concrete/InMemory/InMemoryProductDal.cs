using Core.DataAccess;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal  //memory ile çalışıyorum 
    {
        List<Product> _products;

        public InMemoryProductDal()  //constructor ını çalıştırıyrum çünkü bir veritabanından gelmiyor veriler.
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15 },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 },
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Bardak", UnitPrice = 85, UnitsInStock = 1 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ
            //LAMBDA
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);  //sadece bu şekilde remove yazsak hata verir, silemezdi. 
            //çünkü verdiğim product ın hangi ıd ye sahip product olduğunu bilmiyor.
            // foreach ile bir sürü kod yazıp dönmek yerine linq kullandım memory i zorlamadım. (singleordefault da aynı görevi görüyor)
        }

        public List<Product> GetAll()
        {
            return _products;   //bu _products listesini businessda da kullanacağım bu nedenle return ledim.
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün Id sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;  //update liyorum
            productToUpdate.CategoryId = product.CategoryId;  // gönderdiğim product ın productName ini productToUpdate in productName ine atıyorum.
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)   //IProductDal ın implementasyonu ile burada bulunuyor.
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
            //where içindeki şartı sağlayan yeni bir liste oluşturur ve return ederiz.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}






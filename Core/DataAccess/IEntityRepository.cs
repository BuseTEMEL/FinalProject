
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //T sistemi dinamik yapar ve ne tür istersen onu verir.
    //class :referans tip olabilir dedim ben T için
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new() : newlenebilir olmalı (interface ler newlenemezdi ya.)
    public interface IEntityRepository<T> 
        where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter =null);  //productmanager da list get all da filtre yazmak için bir kere yaparsın.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);  //void ekle ve bitir.
        void Update(T entity);
        void Delete(T entity);

       
    }
}

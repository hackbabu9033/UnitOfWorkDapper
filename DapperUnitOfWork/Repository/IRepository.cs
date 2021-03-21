using DapperUnitOfWork.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperUnitOfWork.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        IEnumerable<T> All();
        void Delete(int id);
        void Delete(T entity);
        T Find(int id);
        void Update(T entity);
    }
}

using DapperUnitOfWork.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace DapperUnitOfWork.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        public virtual void Add(T entity)
        {

        }

        public virtual IEnumerable<T> All()
        {
            return null;
        }


        public virtual void Delete(int id)
        {

        }


        public virtual void Delete(T entity)
        {

        }

        public virtual T Find(int id)
        {
            return null;
        }

        public virtual T FindByName(string name)
        {
            return null;
        }

        public virtual void Update(T entity)
        {

        }
    }
}

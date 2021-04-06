using DapperUnitOfWork.Config;
using DapperUnitOfWork.DAO;
using DapperUnitOfWork.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;
using Unity;
using Unity.Injection;

namespace DapperUnitOfWork
{

    public class UnitOfWork: IDisposable
    {
        private readonly UnityContainer _container;

        private TransactionScope _transactionScope;

        private Dictionary<Type, object> _repositories;

        private SqlConnection _connection;

        private readonly DBConfig _dBConfig;

        private bool _disposed;

        private string _connectionString
        {
            get
            {
                return _dBConfig.NorthwindConn;
            }
        }

        public UnitOfWork(DBConfig dBConfig, UnityContainer container)
        {
            _transactionScope = new TransactionScope();
            _repositories = new Dictionary<Type, object>();
            _dBConfig = dBConfig;
            _container = container;
            _connection = new SqlConnection(_connectionString);
        }

        public IRepository<T> Repository<T>() where T:BaseEntity
        {
            var entityType = typeof(T);
            var repoType = typeof(Repository<>);
            object existedRepository;
            if (_repositories.TryGetValue(entityType, out existedRepository))
            {
                return (IRepository<T>)existedRepository;
            }
            else
            {
                var constructedType = repoType.MakeGenericType(entityType);
                var service = (IRepository<T>)Activator.CreateInstance(constructedType, new Object[] { _connection });
                _repositories.Add(entityType, service);
                return service;
            }
        }

        /// <summary>
        /// 直接所有對資料庫的異動
        /// </summary>
        public void SaveChange()
        {
            try
            {
                using (_transactionScope)
                {



                    _transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                _transactionScope.Dispose();
                throw;
            }
            finally
            {
                _transactionScope.Dispose();
            }
            return;
        }

        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        /// <param name="disposing">是否在清理中？</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

                }
            }

            _disposed = true;
        }
    }

}

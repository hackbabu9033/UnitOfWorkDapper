using DapperUnitOfWork.Config;
using DapperUnitOfWork.DAO;
using DapperUnitOfWork.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace DapperUnitOfWork
{
    public class UnitOfWork: IDisposable
    {
        private TransactionScope _transactionScope;

        private Dictionary<Type, object> _repositories;

        private readonly SqlConnection _connection;

        private readonly DBConfig _dBConfig;

        private bool _disposed;


        private string _connectionString
        {
            get
            {
                return _dBConfig.NorthwindConn;
            }
        }

        public UnitOfWork(DBConfig dBConfig)
        {
            _transactionScope = new TransactionScope();
            _repositories = new Dictionary<Type, object>();
            dBConfig = _dBConfig;
        }


        public void SaveChange()
        {
            try
            {
                using (var scope = _transactionScope)
                {
                    scope.Complete();
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

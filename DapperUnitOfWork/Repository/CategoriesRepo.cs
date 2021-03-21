using DapperUnitOfWork.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using DapperUnitOfWork.Config;
using Dapper;
using System.Data.SqlClient;

namespace DapperUnitOfWork.Repository
{
    public class CategoriesRepo : IRepository<Categories>
    {
        private readonly SqlConnection _sqlConnection;

        public CategoriesRepo(SqlConnection connection)
        {
            // Repository本身的sql connection改由UnitOfWork掌管
            _sqlConnection = connection;
        }

        public void Add(Categories entity)
        {
            var sql = $@"insert into (CategoryName,Description,Picture)
                        values (@food,@test,@picture)";
            using (var conn = _sqlConnection)
            {
                conn.Execute(sql);
            }
        }

        public IEnumerable<Categories> All()
        {
            var sql = $@"select * from Categories";
            using (var conn = _sqlConnection)
            {
                return conn.Query<Categories>(sql);
            }
        }

        public void Delete(int id)
        {
            var sql = $@"delete from Categories
                         where CategoryID = @Id";
            using (var conn = _sqlConnection)
            {
                conn.Execute(sql, new { id = id });
            }
        }

        public void Delete(Categories entity)
        {
            var sql = $@"delete from Categories
                         where CategoryID = @Id";
            using (var conn = _sqlConnection)
            {
                conn.Execute(sql, new { id = entity.Id });
            }
        }

        public Categories Find(int id)
        {
            var sql = $@"select from Categories
                         where CategoryID = @Id";
            using (var conn = _sqlConnection)
            {
                return conn.QueryFirst(sql, new { id = id });
            }
        }

        public void Update(Categories entity)
        {
            var sql = $@"update Categories
                        set CategoryName = @CategoryName,
                        Description = @Description,
                        Picture = @Picture,
                        where CategoryID = @Id";
            using (var conn = _sqlConnection)
            {
                conn.Execute(sql, new
                {
                    @CategoryName = entity.CategoryName,
                    @Description = entity.Description,
                    @Picture = entity.Picture
                });
            }
        }
    }
}

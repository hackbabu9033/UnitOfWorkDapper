using DapperUnitOfWork.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Unity;

namespace DapperUnitOfWork.Repository
{
    public class CustomersRepo : IRepository<Customers>
    {
        private readonly SqlConnection _conn;

        public CustomersRepo()
        {
            
        }
        public void Add(Customers entity)
        {
            var sql = @"INSERT INTO Customers
                       ([CustomerID],[CompanyName],[ContactName],
                        [ContactTitle],[Address],[City],[Region],
                        [PostalCode],[Country],[Phone],[Fax])
                       VALUES
                       (
                            @CustomerID,@CompanyName,@ContactName,
                            @ContactTitle,@Address,@City,@Region,
                            @PostalCode,@Country,@Phone,@Fax
                       )";
            _conn.Execute(sql, entity);
        }

        public IEnumerable<Customers> All()
        {
            var sql = @"SELECT * FROM Customers";
            return _conn.Query<Customers>(sql);
        }

        public void Delete(int id)
        {
            var sql = @"delete from Customers
                         where CustomerID = @Id";
            _conn.Execute(sql);
        }

        public void Delete(Customers entity)
        {
            var sql = @"delete from Customers
                         where CustomerID = @Id";

            _conn.Execute(sql, new { entity.Id });
        }

        public Customers Find(int id)
        {
            var sql = @"select from Customers
                         where CustomerID = @Id";

            return _conn.QueryFirst(sql, new { id = id });
        }

        public void Update(Customers entity)
        {
            var sql = @"update Customers
                        set CompanyName = @CompanyName,
                        ContactName = @ContactName,
                        ContactTitle = @ContactTitle,
                        Address = @Address,
                        City = @City,
                        Region = @Region,
                        PostalCode = @PostalCode,
                        Country = @Country,
                        Phone = @Phone,
                        Fax = @Fax,
                        where CustomerID = @Id";
            _conn.Execute(sql, entity);
        }
    }
}

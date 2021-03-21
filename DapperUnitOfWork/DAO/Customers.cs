using System;
using System.Collections.Generic;
using System.Text;

namespace DapperUnitOfWork.DAO
{
    public class Customers : BaseEntity
    {
        public override string Id { get { return CustomerID; } }
        public string CustomerID { set; get; }
        public string CompanyName { set; get; }
        public string ContactName { set; get; }
        public byte[]? Picture { set; get; }
    }
}

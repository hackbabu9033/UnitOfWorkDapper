using System;
using System.Collections.Generic;
using System.Text;

namespace DapperUnitOfWork.DAO
{
    public class Categories : BaseEntity
    {
        public override string Id { get { return CategoryID.ToString(); } }
        public int CategoryID { get; }
        public string CategoryName { set; get; }
        public string? Description { set; get; }
        public byte[]? Picture { set; get; }
    }
}

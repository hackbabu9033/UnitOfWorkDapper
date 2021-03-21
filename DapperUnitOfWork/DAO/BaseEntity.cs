using System;
using System.Collections.Generic;
using System.Text;

namespace DapperUnitOfWork.DAO
{
    public class BaseEntity
    {
        /// <summary>
        /// primary key
        /// </summary>
        public virtual string Id { set; get; }

    }
}

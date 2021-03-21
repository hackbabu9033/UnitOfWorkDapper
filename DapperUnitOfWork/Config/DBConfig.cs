using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperUnitOfWork.Config
{
    public class DBConfig
    {
        //hack : use MSDI to inject IConfiguration
        private readonly IConfiguration _config;

        public DBConfig(IConfiguration config)
        {
            _config = config;
        }

        public string NorthwindConn
        {
            get
            {
                return _config.GetConnectionString("NorthWind");
            }
        }
    }
}

using DapperUnitOfWork.DAO;
using DapperUnitOfWork.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DapperUnitOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //var unitOfWork = new UnitOfWork();
            var cateRepo = new Repository<Categories>();
            Console.WriteLine("aaa");

            SetConfig();
            var serviceCollection = new ServiceCollection()
                //This BuildServiceProvider process is equivalent to the ConfigureServices method in an ASP.NET Core project
                .BuildServiceProvider();
        }

        private static void SetDependencyInjection(IServiceCollection services)
        {

        }

        public static void SetConfig()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();


        }
    }
}

using DapperUnitOfWork.Config;
using DapperUnitOfWork.DAO;
using DapperUnitOfWork.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Unity;

namespace DapperUnitOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = SetConfig();
            var unityContainer = new UnityContainer();
            unityContainer.RegisterInstance(config);
            var dbconfig = unityContainer.Resolve<DBConfig>();
            var unitOfWork = new UnitOfWork(dbconfig, unityContainer);
            var category = unitOfWork.Repository<Categories>().Find(5);
            category.CategoryName = "new category";
            unitOfWork.Repository<Categories>().Update(category);
            unitOfWork.SaveChange();
        }

        public static IConfiguration SetConfig()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return config;
        }
    }
}

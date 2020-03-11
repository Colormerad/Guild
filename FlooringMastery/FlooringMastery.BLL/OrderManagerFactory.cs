using FlooringMastery.Data;
using Microsoft.IdentityModel.Protocols;
using NLog.Internal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FlooringMastery.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "TestRepository":
                    return new OrderManager(new TestRepository(), new TestProdRepo(), new TestStateTaxRepo());
                case "OrderRepositoryFile":
                    return new OrderManager(new OrderRepositoryFile(), new ProductRepositoryFile(),  new StateTaxRepositoryFile());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}

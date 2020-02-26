using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SWGDAL;

namespace SWGLogic
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch(mode)
            {
                case "prod":
                    return new OrderManager(new ProductionRepoOrders(), new ProductionRepoProducts(), new ProductionRepoTaxes());
                case "test":
                    return new OrderManager(new TestRepoOrders(), new TestRepoProducts(), new TestRepoTaxes());
                default:
                    return new OrderManager(new ProductionRepoOrders(), new ProductionRepoProducts(), new ProductionRepoTaxes());
            }
        }
    }
}

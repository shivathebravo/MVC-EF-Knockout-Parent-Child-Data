namespace SolutionName.DataLayer.Migrations
{
    using SolutionName.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(SalesContext context)
        {

            context.SalesOrders.AddOrUpdate(
              so => so.CustomerName,
              new SalesOrder
              {
                  CustomerName = "Andrew Peters",
                  PONumber = "123",
                  SalesOrderItems ={
                                           new SalesOrderItem{ProductCode="ABC123",Quantity=10,UnitPrice=1.23m},
                                           new SalesOrderItem{ProductCode="DEF123",Quantity=12,UnitPrice=4.23m},
                                           new SalesOrderItem{ProductCode="xyz",Quantity=1,UnitPrice=56.23m}
                                   }


              },
              new SalesOrder { CustomerName = "Brice Lambson", PONumber = "456" },
              new SalesOrder { CustomerName = "Rowan Miller", PONumber = "789" }
            );

        }
    }
}

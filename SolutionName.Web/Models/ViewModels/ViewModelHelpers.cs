using SolutionName.Model;
using SolutionName.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionName.Web.Models.ViewModels
{
   public static  class ViewModelHelpers
    {

       public static SalesOrderViewModel CreateSalesOrderViewModelFromSalesOrder(SalesOrder salesOrder)
       {
           SalesOrderViewModel salesOrderViewModel = new SalesOrderViewModel();
           salesOrderViewModel.SalesOrderId = salesOrder.Id;
           salesOrderViewModel.CustomerName = salesOrder.CustomerName;
           salesOrderViewModel.PONumber = salesOrder.PONumber;

           return salesOrderViewModel;
       }

       public static SalesOrder CreateSalesOrderFromSalesOrderViewModel(SalesOrderViewModel saleOrderViewModel)
       {

           SalesOrder salesOrder = new SalesOrder();
           salesOrder.Id = saleOrderViewModel.SalesOrderId;
           salesOrder.CustomerName = saleOrderViewModel.CustomerName;
           salesOrder.PONumber = saleOrderViewModel.PONumber;
           return salesOrder;
       }

       public static string GetMessageToClient(ObjectState objectState, string customerName)

       {
           string meeesageToClient = string.Empty;
           switch (objectState)
           {
               case ObjectState.Added:
                   meeesageToClient = string.Format("A's sales order for{0} has been added to the database", customerName);
                   break;
               case ObjectState.Modified:
                   meeesageToClient = string.Format("The Custoemr name for this sales order has been updated to {0}", customerName);
                   break;
           }
           return meeesageToClient;


       }
    }
}

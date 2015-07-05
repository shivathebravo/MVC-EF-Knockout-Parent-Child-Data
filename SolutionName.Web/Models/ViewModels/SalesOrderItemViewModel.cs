using SolutionName.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionName.Web.Models.ViewModels
{
   public class SalesOrderItemViewModel:IObjectWithState


    {
       public SalesOrderItemViewModel()
       {
           SalesOrderItems = new List<SalesOrderItemViewModel>();
       }
        public int SalesOrderItemId { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int SalesOrderId { get; set; }
        public ObjectState ObjectState{get ;set;}

        public List<SalesOrderItemViewModel> SalesOrderItems { get; set; }
        
        }
}

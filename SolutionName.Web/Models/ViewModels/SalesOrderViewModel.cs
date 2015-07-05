using SolutionName.Model;
using SolutionName.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionName.Web.ViewModels
{
    public class SalesOrderViewModel:IObjectWithState


    {
        public SalesOrderViewModel()
        {
            SalesOrderItems = new List<SalesOrderItemViewModel>();
        }
        public int SalesOrderId { get; set; }
        public string CustomerName { get; set; }
        public string PONumber { get; set; }
        public string MessageToClient { get; set; }

        public ObjectState ObjectState
        {
            
            get;set;
        }

        public List<SalesOrderItemViewModel> SalesOrderItems { get; set; }
    }
}

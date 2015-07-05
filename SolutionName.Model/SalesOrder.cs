﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionName.Model
{
    public class SalesOrder : IObjectWithState
    {

        public SalesOrder()
        {
            SalesOrderItems = new List<SalesOrderItem>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PONumber { get; set; }
      
        public ObjectState ObjectState
        {
            get;
            set;
        }

        public virtual List<SalesOrderItem> SalesOrderItems { get; set; }
    }
}

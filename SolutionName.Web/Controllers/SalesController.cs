using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SolutionName.DataLayer;
using SolutionName.Model;
using SolutionName.Web.ViewModels;
using SolutionName.Web.Models.ViewModels;



namespace SolutionName.Web.Controllers
{
    public class SalesController : Controller
    {
        private SalesContext _salesContext;

        public SalesController()
        {
            _salesContext = new SalesContext();
        }

        public ActionResult Index()
        {
            return View(_salesContext.SalesOrders.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = _salesContext.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            SalesOrderViewModel salesorderViewModel = new SalesOrderViewModel();
            salesorderViewModel.SalesOrderId = salesOrder.Id;
            salesorderViewModel.CustomerName = salesOrder.CustomerName;
            salesorderViewModel.PONumber = salesOrder.PONumber;
            salesorderViewModel.MessageToClient = "Message from view model";
            return View(salesorderViewModel);
        }


        public ActionResult Create()
        {
            SalesOrderViewModel salesorderviewmodel = new SalesOrderViewModel();
            salesorderviewmodel.ObjectState = ObjectState.Added;
            return View(salesorderviewmodel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerName,PONumber")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                _salesContext.SalesOrders.Add(salesOrder);
                _salesContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesOrder);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = _salesContext.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }

            SalesOrderViewModel salesorderViewModel = ViewModelHelpers.CreateSalesOrderViewModelFromSalesOrder(salesOrder);

            salesorderViewModel.MessageToClient = string.Format("The original values of Customer Name is {0}", salesorderViewModel.CustomerName);
           
            return View(salesorderViewModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,CustomerName,PONumber")] SalesOrder salesOrder)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _salesContext.Entry(salesOrder).State = EntityState.Modified;
        //        _salesContext.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(salesOrder);
        //}

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = _salesContext.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            SalesOrderViewModel salesorderViewModel = ViewModelHelpers.CreateSalesOrderViewModelFromSalesOrder(salesOrder);
            salesorderViewModel.MessageToClient = string.Format("You are about to permanent delete");
           
            return View(salesorderViewModel);
        }


       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _salesContext.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult Save(SalesOrderViewModel salesOrderViewModel)
        {
            SalesOrder salesOrder = ViewModelHelpers.CreateSalesOrderFromSalesOrderViewModel(salesOrderViewModel);
        
            salesOrder.ObjectState = salesOrderViewModel.ObjectState;

            _salesContext.SalesOrders.Attach(salesOrder);
            _salesContext.ApplyStateChanges();

            _salesContext.SaveChanges();


            if (salesOrder.ObjectState == ObjectState.Deleted)
            {
                return Json(new { newLocation = "/Sales/Index/" });
            }

            salesOrderViewModel.MessageToClient = ViewModelHelpers.GetMessageToClient(salesOrderViewModel.ObjectState, salesOrder.CustomerName);
           
            salesOrderViewModel.SalesOrderId = salesOrder.Id;
            salesOrderViewModel.ObjectState = ObjectState.Unchanged;


            return Json(new { salesOrderViewModel });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerOrder.Data;
using CustomerOrder.Models;

namespace CustomerOrder.Controllers
{
    //[Authorize] => no users set, so Acess denied.
    //[AllowAnonymous]
    //[Authorize]
    //[Route("Orders")]
    //[RoutePrefix("OrdersLog")]
    public class OrdersController : Controller
    {
        public CustomerOrderContext db = new CustomerOrderContext();

        // GET: Orders
        //gets written after base address
        //This will even skip the controller.
        //[Route("ShowData/NormalView")]

        // The '~' will skip the root prefix
        //[Route("~/ShowData/NormalView")]

        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer);
            ViewBag.Customers = db.Customers.ToList();

          
            return View(orders.ToList());
        }
        [HttpPost]
        [NoCustomersExcpetionHandler]
        public ActionResult Index(FormCollection collection)
        {

            var CustomerID = 0;

            if (int.TryParse(collection["CustomerID"], out int _CustomerID))
                CustomerID = _CustomerID;

            int orderCount = db.Orders.Count(o => o.CustID == CustomerID);

            if (orderCount == 0)
                // You can throw anything, we just need an exception. 
                throw new NoOrdersFoundException(CustomerID);
            else
            {
                ViewBag.Customers = db.Customers.ToList();
                var filteredOrders = new List<Order>();
                filteredOrders = db.Orders.Where(p => p.CustID == CustomerID).ToList();
                return View(filteredOrders);
            }
            
        }

        public class NoOrdersFoundException : Exception
        {
            public int CustomerId { get; private set; }

            public NoOrdersFoundException(int customerId) : base($"No orders found for customer ID {customerId}")
            {
                CustomerId = customerId;
            }
        }

        // GET: Orders/Details/5
        [MyLogFilter]
        //[NonAction]
        //[ActionName("myDetails")]
        //[AcceptVerbs("GET","DELETE")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        //[AllowAnonymous] // Will be the only one that opens, it's [post] is blocked.
        public ActionResult Create()
        {
            ViewBag.CustID = new SelectList(db.Customers, "ID", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,TotalPrice,CustID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustID = new SelectList(db.Customers, "ID", "Name", order.CustID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustID = new SelectList(db.Customers, "ID", "Name", order.CustID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,TotalPrice,CustID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustID = new SelectList(db.Customers, "ID", "Name", order.CustID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

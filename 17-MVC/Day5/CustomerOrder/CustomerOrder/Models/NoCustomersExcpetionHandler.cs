using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerOrder.Controllers;
using CustomerOrder.Data;

namespace CustomerOrder.Models
{
    public class NoCustomersExcpetionHandler : HandleErrorAttribute //FilterAttribute, IExceptionFilter
    {
        private readonly CustomerOrderContext db = new CustomerOrderContext();
        public override void OnException(ExceptionContext filterContext)
        {


            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "myErrorPage"
            };

            base.OnException(filterContext);

            //if(filterContext.ExceptionHandled || filterContext.HttpContext.IsCustomErrorEnabled == true)
            //{
            //}



            //var CustomerID = 0; 

            //if (int.TryParse(filterContext.HttpContext.Request["CustomerID"], out int _CustomerID))
            //    CustomerID = _CustomerID;

            //    int orderCount = db.Orders.Count(o => o.CustID == CustomerID);

            //if (orderCount == 0)
            //{


            //}

        }
    }
}
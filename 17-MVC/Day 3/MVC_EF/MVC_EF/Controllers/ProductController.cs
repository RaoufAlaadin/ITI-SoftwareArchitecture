using MVC_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_EF.Controllers
{
    public class ProductController : Controller
    {
        // Creating our local copy from the database.
        NorthwindEntities context = new NorthwindEntities();

        #region FilterBySupplier (Action + View)
       

        //public ActionResult FilterBySupplier(FormCollection collection)
        //{

        //    var filteredProducts = new List<Product>();
        //    if (int.TryParse(collection["SupplierID"], out int supplierId))
        //        filteredProducts = context.Products.Where(p => p.SupplierID == supplierId).ToList();


        //    return View(filteredProducts);
        //}

        #endregion

        #region GetAll/GetByID

        // GET: Product
        public ActionResult Index()
        {
            ViewBag.Suppliers = context.Suppliers.ToList();

            return View(context.Products);
        }



        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            ViewBag.Suppliers = context.Suppliers.ToList();

            var filteredProducts = new List<Product>();
            if (int.TryParse(collection["SupplierID"], out int supplierId))
                filteredProducts = context.Products.Where(p => p.SupplierID == supplierId).ToList();


            return View(filteredProducts);
        }




        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var selectedProduct = context.Products.FirstOrDefault(x => x.ProductID == id);

            return View(selectedProduct);
        }

        #endregion

        #region Create a new Product
        // GET: Product/Create

        public ActionResult Create()
        {
            // This gives us a List of all the suppliers avialable to us.
            ViewBag.Suppliers = context.Suppliers.ToList();


            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var newProductID = context.Products.Max(x => x.ProductID) + 1;

                Product newProduct = new Product();

                /*  Note about (ID Sequence) : 
                The ID is going to be last given by the column Identity, even if you deleted
                some rows, the Identity won't reset, and the Linq command is return the last identity used, 

                 to reset the identity after deletion use the following sql statement 

                    DBCC CHECKIDENT ('Products', RESEED, (SELECT MAX(ProductID) FROM Products))
                 */

                newProduct.ProductID = newProductID;

                newProduct.ProductName = collection["ProductName"];

                if (int.TryParse(collection["SupplierID"], out int supplierId))
                    newProduct.SupplierID = supplierId;


                if (int.TryParse(collection["CategoryID"], out int categoryId))
                    newProduct.CategoryID = categoryId;

                newProduct.QuantityPerUnit = collection["QuantityPerUnit"];

                if (decimal.TryParse(collection["UnitPrice"], out decimal unitPrice))
                    newProduct.UnitPrice = unitPrice;

                if (short.TryParse(collection["UnitsInStock"], out short unitsInStock))
                    newProduct.UnitsInStock = unitsInStock;

                if (short.TryParse(collection["UnitsOnOrder"], out short unitsOnOrder))
                    newProduct.UnitsOnOrder = unitsOnOrder;

                if (short.TryParse(collection["ReorderLevel"], out short reorderLevel))
                    newProduct.ReorderLevel = reorderLevel;

                if (bool.TryParse(collection["Discontinued"], out bool Discontinued))
                    newProduct.Discontinued = Discontinued;


                context.Products.Add(newProduct);

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Edit a Current Product
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = context.Products.Find(id);

            ViewBag.Suppliers = context.Suppliers.ToList();


            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Product product = context.Products.Find(id);
                product.ProductName = collection["ProductName"];

                if (int.TryParse(collection["SupplierID"], out int supplierId))
                    product.SupplierID = supplierId;

                if (int.TryParse(collection["CategoryID"], out int categoryId))
                    product.CategoryID = categoryId;

                product.QuantityPerUnit = collection["QuantityPerUnit"];

                if (decimal.TryParse(collection["UnitPrice"], out decimal unitPrice))
                    product.UnitPrice = unitPrice;

                if (short.TryParse(collection["UnitsInStock"], out short unitsInStock))
                    product.UnitsInStock = unitsInStock;

                if (short.TryParse(collection["UnitsOnOrder"], out short unitsOnOrder))
                    product.UnitsOnOrder = unitsOnOrder;

                if (short.TryParse(collection["ReorderLevel"], out short reorderLevel))
                    product.ReorderLevel = reorderLevel;


                if (bool.TryParse(collection["Discontinued"], out bool Discontinued))
                    product.Discontinued = Discontinued;



                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete a Product
        /*Note: 
            Why do we have GET/POST for delete ? 
        => Because it's considered best practice to delete by submiting a form,
            Where you confirm that you want to delete that record. 
        */
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var deletedProduct = context.Products.Find(id);


            return View(deletedProduct);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var deletedProduct = context.Products.Find(id);
                context.Products.Remove(deletedProduct);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 
        #endregion
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SinglaRDemoReaouf.Hubs;
using SinglaRDemoReaouf.Models;

namespace SinglaRDemoReaouf.Controllers
{
    public class ProductController : Controller
    {
        #region Dependency Injection using Ctor

        private readonly MyDBContext context;
        private readonly IHubContext<ProductHub> productHub;

        public ProductController(MyDBContext _context, IHubContext<ProductHub> _productHub)
        {
            context = _context;
            productHub = _productHub;
        } 

        #endregion


        // GET: ProductController
        public ActionResult Index()
        {
            var ProductList = context.Products.ToList();

            return View(ProductList);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = context.Products.Include(c => c.Comments).SingleOrDefault(p => p.Id == id);

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product newProduct)
        {

            context.Products.Add(newProduct);
            context.SaveChanges();

            productHub.Clients.All.SendAsync("NotifyNewProduct", newProduct);

             return View();

            //try
            //{


            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

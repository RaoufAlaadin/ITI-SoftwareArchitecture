using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Model;


namespace WebApplication1.Controllers

{
    public class ProductController : Controller
    {
        #region Adding DBContext using Injection
        /* Wrong - tightly coupled, 
         So we need to pass using ctor*/

        //ProductDBContext dBContext = new ProductDBContext(); 

        /*  public ProductDBContext Context { get; }
          public ProductController(ProductDBContext context)
          {
              Context = context;
          }*/
        #endregion


        public string calc(int x,int y)
        {
            return (x+y).ToString();
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(ProductList.Products.ToList());
            //return View(Context.Products.ToList());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod)
        {
            try
            {
                ProductList.Products.Add(prod);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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

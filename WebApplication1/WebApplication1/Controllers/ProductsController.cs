using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {

        private dbgeneration _context;

        public ProductsController()
        {
            _context = new dbgeneration();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Products
        public ActionResult AllProducts()
        {

            var Getproducts = _context.GetProducts.ToList();

            return View(Getproducts);
        }

        [HttpPost]
        public ActionResult SaveProduct(Product product) {

            _context.GetProducts.Add(product);
            _context.SaveChanges();



            return RedirectToAction("AllProducts", "Products");
        }

        public ActionResult addProduct()
        {

            return View();

        }


        [Route("~/Product/{i}")]
        public ActionResult ProductDetails(string i)
        {

            var product = _context.GetProducts.SingleOrDefault(c => c.ProductName == i);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

    }
}
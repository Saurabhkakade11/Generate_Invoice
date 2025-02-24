

using Generate_Invoice.Models;
using System.Linq;
using System.Web.Mvc;

namespace Generate_Invoice.Controllers
{
    public class ProductController : Controller
    {
        private readonly InvoiceDbEntities db;

        public ProductController()
        {
            db = new InvoiceDbEntities();
        }
        
        // Index GET action to render the product list
        public ActionResult Index()
        {
            Product p = new Product();
            ViewBag.vproduct = db.Products.ToList();
            return View(p);
        }

        // Add a product using an AJAX call done
        [HttpPost]
        public JsonResult AddProduct(Product prod)
        {
            if (prod != null)
            {
                db.Products.Add(prod);
                db.SaveChanges();
                return Json("Product added successfully", JsonRequestBehavior.AllowGet);
            }
            return Json("Failed to add product", JsonRequestBehavior.AllowGet);
        }
        
        // Get all products as a JSON response
        public JsonResult GetAllProduct()
        {
            var products = db.Products.ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }


        
        // Update product using an AJAX call
        [HttpPost] // Used POST instead of PUT for ASP.NET compatibility
        public JsonResult UpdateProduct(Product prod)
        {
            var existingProduct = db.Products.FirstOrDefault(p => p.product_id == prod.product_id);
            if (existingProduct != null)
            {
                existingProduct.product_name = prod.product_name;
                existingProduct.rate = prod.rate;
                existingProduct.GST = prod.GST;
                existingProduct.stock_quantity = prod.stock_quantity;

                db.SaveChanges();
                return Json("Product updated successfully", JsonRequestBehavior.AllowGet);
            }
            return Json("Failed to update product", JsonRequestBehavior.AllowGet);
        }
       
        
        // Delete a product by ID
        [HttpPost] // Using POST instead of DELETE for better compatibility
        public JsonResult DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return Json("Product deleted successfully", JsonRequestBehavior.AllowGet);
            }
            return Json("Product not found", JsonRequestBehavior.AllowGet);
        }
        
        // Get all products by id as a JSON response
        public JsonResult GetProductById(int id)
        {
            var product = db.Products.Find(id);
            return product != null
                ? Json(product, JsonRequestBehavior.AllowGet)
                : Json("Product not found", JsonRequestBehavior.AllowGet);
        }

        // Get all products as a JSON response
        //public JsonResult GetProductById(int id)
        //{
        //  var product = db.Products.Find(id);
        //  if (product != null)
        //   {
        //      return Json(product, JsonRequestBehavior.AllowGet);
        //   }
        //      return Json("Product not found", JsonRequestBehavior.AllowGet);
        //}
    }
}

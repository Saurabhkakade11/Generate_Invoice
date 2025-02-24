using Generate_Invoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generate_Invoice.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceDbEntities db;
        public InvoiceController()
        {
            db= new InvoiceDbEntities();
        }
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenerateInvoice()
        {
            ViewBag.vcustomer = new SelectList(db.Customers.ToList(), "customer_id", "customer_name");
            ViewBag.vproduct = new SelectList(db.Products.ToList(), "product_id", "product_name");
            return View();
        }

        //Get all products as a JSON response
        public JsonResult GetProductById(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                return Json(product, JsonRequestBehavior.AllowGet);
            }
            return Json("Product not found", JsonRequestBehavior.AllowGet);
        }

        ////same code above 
        //[HttpGet]
        //public JsonResult GetProductByID(int id)
        //{
        //    Product p = db.Products.Find(id);
        //    Product tp = new Product()
        //    {
        //        product_id = p.product_id,
        //        product_name = p.product_name,
        //        rate = p.rate,
        //        GST = p.GST,
        //        stock_quantity = p.stock_quantity
        //    };
        //    return Json(tp, JsonRequestBehavior.AllowGet);
        //}

        public List<Customer> GetAllCustomer()
        {
            List<Customer> lst= new List<Customer>();
            foreach (Customer c in db.Customers.ToList())
            {
                lst.Add(new Customer()
                {
                    customer_id=c.customer_id,
                    customer_name=c.customer_name,
                    customer_email=c.customer_email,    
                    mobile_no=c.mobile_no,
                    city=c.city,
                });
            }
            return lst;
        }
        public JsonResult GetALLLLLCustomers()
        {
            return Json(GetAllCustomer(), JsonRequestBehavior.AllowGet);
        }
      

        [HttpPost]
        public String GenerateInvoice(InvoiceDetail d)
        {
            db.InvoiceDetails.Add(d);
            db.SaveChanges();
            return "Invoice Generated Succesfully";
        }



        //View-All-Generated-Invoices

        public ActionResult AllInvoices()
        {
            List<InvoiceModel> lst = GetAllInvoices();
            return View(lst);
        }

        public List<InvoiceModel> GetAllInvoices()
        {
            List<InvoiceModel> lst = new List<InvoiceModel>();

            foreach (InvoiceDetail d in db.InvoiceDetails.ToList())
            {
                float paid_amount = 0, remaining_amount = 0, total_amount = 0;
                List<InvoicePayment> payments = db.InvoicePayments.ToList().Where(e => e.invoice_id.Equals(d.invoice_id)).ToList();
                foreach (InvoicePayment p in payments)
                {
                    paid_amount += (float)p.payment_amount;
                }
                total_amount = (float)d.total_amount;
                remaining_amount = total_amount - paid_amount;
                string status = "";
                if (paid_amount == 0)
                {
                    status = "Un Paid";
                }
                else if (paid_amount > 0 && paid_amount < total_amount)
                {
                    status = "Partial Paid";
                }
                else
                {
                    status = "Paid";
                }
                Customer cust = db.Customers.Find(d.customer_id);
                InvoiceModel im = new InvoiceModel()
                {
                    customer_id = (int)d.customer_id,
                    customer_name = cust.customer_name,
                    invoice_date = d.invoice_date.Value.ToShortDateString(),
                    invoice_id = d.invoice_id,
                    paid_amount = paid_amount,
                    remaining_amount = remaining_amount,
                    total_amount = total_amount,
                    status = status
                };
                lst.Add(im);
            }
            return lst;
        }



        //Pay Now
        public ActionResult PayNow(int id)
        {
            InvoiceModel m = GetAllInvoices().FirstOrDefault(e=>e.invoice_id.Equals(id));
            ViewBag.vinvoice = m;

            InvoicePayment p = new InvoicePayment() { invoice_id = m.invoice_id };
            return View(p);
        }

        [HttpPost]
        public ActionResult PayNow(InvoicePayment p)
        {
            db.InvoicePayments.Add(p);
            db.SaveChanges();
            return RedirectToAction("AllInvoices");
        }

        //View Invoices 

        public ActionResult ViewInvoice(int id)
        {
            InvoiceModel m = GetAllInvoices().FirstOrDefault(e => e.invoice_id.Equals(id));
            InvoiceDetail d = db.InvoiceDetails.Find(id);
            ViewBag.invoice = m;
            return View(d);
        }


    }

}
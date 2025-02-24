using Generate_Invoice.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generate_Invoice.Controllers
{
    public class CustomerController : Controller
    {

        private readonly InvoiceDbEntities db;

        public CustomerController()
        {
            db = new InvoiceDbEntities();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create()
        {
            ViewBag.vcustomer = db.Customers.ToList();
            //List<Customer> lst =db.Customers.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult Create(Customer cus)
        {
            //this os one way
            //bool isduplicate = db.students.Any(st => st.Student_name == s.Student_name);
            //if (isduplicate)
            //{
            //    ViewBag.msg = "Student Is Already Exit...";
            //}
            if (db.Customers.Any(c => c.customer_name == cus.customer_name))
            {
                ViewBag.msg = "Customer Already Exists";
            }
            else
            {
                db.Customers.Add(cus);
                db.SaveChanges();
                ViewBag.msg = "Customer Added Successfully.";
            }
            ViewBag.vcustomer = db.Customers.ToList();
            //return RedirectToAction("Create");
            return View("Create");


            //The error System.Data.Entity.Core.EntityException:
            //'The underlying provider failed on Open.' typically occurs when there's an issue connecting to the database. 
        }

        public ActionResult Edit(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer cust)
        {
            if (ModelState.IsValid)
            {
                var existingCustomer = db.Customers.Find(cust.customer_id);
                if (existingCustomer != null)
                {
                    existingCustomer.customer_name = cust.customer_name;
                    existingCustomer.customer_email = cust.customer_email;
                    existingCustomer.mobile_no = cust.mobile_no;
                    existingCustomer.city = cust.city;
                    db.SaveChanges();

                    TempData["msg"] = "Customer updated successfully!";
                    return RedirectToAction("Create");
                }
                TempData["msg"] = "Customer not found!";
            }
            return View(cust);
        }

        public ActionResult Delete(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
                TempData["msg"] = "Customer Deleted Successfully.";
            }
            else
            {
                TempData["msg"] = "Customer Not Found.";
            }
            return RedirectToAction("Create");
        }


        //it is for select tag option ajax call 
        public JsonResult GetAllCustomer(Customer cus)
        {
            if (cus != null)
            {
                var customer = db.Customers.ToList();
                return Json(customer, JsonRequestBehavior.AllowGet);
            }
            return Json("Customer Not Found");
        }
    }
}

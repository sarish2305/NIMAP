using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nimap_CRUD_Operation.Models;

namespace Nimap_CRUD_Operation.Controllers
{
    public class ProductCRUDController : Controller
    {
        private Nimap_CRUDEntities db = new Nimap_CRUDEntities();

        // GET: ProductCRUD
        public ActionResult AddProduct()
        {
            return View(db.ProductMasters.ToList());
        }

       

        // GET: ProductCRUD/Create
        public ActionResult CreateProduct()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult CreateProduct([Bind(Include = "ProductID,ProductName")] ProductMaster productMaster)
        {
            if (ModelState.IsValid)
            {
                db.ProductMasters.Add(productMaster);
                db.SaveChanges();
                return RedirectToAction("AddProduct");
            }

            return View(productMaster);
        }

       
        public ActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster productMaster = db.ProductMasters.Find(id);
            if (productMaster == null)
            {
                return HttpNotFound();
            }
            return View(productMaster);
        }

        
        [HttpPost]
      
        public ActionResult ProductEdit([Bind(Include = "ProductID,ProductName")] ProductMaster productMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AddProduct");
            }
            return View(productMaster);
        }

      
        public ActionResult ProductDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster productMaster = db.ProductMasters.Find(id);
            if (productMaster == null)
            {
                return HttpNotFound();
            }
            return View(productMaster);
        }

        // POST: ProductCRUD/Delete/5
        [HttpPost, ActionName("ProductDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductMaster productMaster = db.ProductMasters.Find(id);
            db.ProductMasters.Remove(productMaster);
            db.SaveChanges();
            return RedirectToAction("AddProduct");
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

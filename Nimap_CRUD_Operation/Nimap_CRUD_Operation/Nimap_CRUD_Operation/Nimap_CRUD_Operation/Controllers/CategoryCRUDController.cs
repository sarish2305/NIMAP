using Nimap_CRUD_Operation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Nimap_CRUD_Operation.Controllers
{
    public class CategoryCRUDController : Controller
    {
        //DB connnection String
        private Nimap_CRUDEntities db = new Nimap_CRUDEntities();
        // GET: CategoryCRUD
        public ActionResult CategoryDisplayRecord()
        {
            return View(db.CategoryMasters.ToList());
        }

        //Create Category
        public ActionResult CreateCategory()
        {
            return View();
        }

        //Insert category Record
        [HttpPost]
        public ActionResult CreateCategory(CategoryMaster categoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.CategoryMasters.Add(categoryMaster);
                db.SaveChanges();
                return RedirectToAction("CategoryDisplayRecord");
            }

            return View(categoryMaster);
        }

        //Get Record ID for Update
        public ActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = db.CategoryMasters.Find(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        //Code for Update 
        [HttpPost]
        public ActionResult CategoryEdit([Bind(Include = "CategoryID,CategoryName")] CategoryMaster categoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CategoryDisplayRecord");
            }
            return View(categoryMaster);
        }

        //Code for delete 

        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = db.CategoryMasters.Find(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // POST: CategoryMasters/Delete/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryMaster categoryMaster = db.CategoryMasters.Find(id);
            db.CategoryMasters.Remove(categoryMaster);
            db.SaveChanges();
            return RedirectToAction("CategoryDisplayRecord");
        }
    }
}
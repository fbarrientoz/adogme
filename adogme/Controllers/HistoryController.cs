using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using adogme.Models;

namespace adogme.Controllers
{
    public class HistoryController : Controller
    {
        private adogmeEntities db = new adogmeEntities();

        // GET: History
        public ActionResult Index()
        {
            var hISTORies = db.HISTORies.Include(h => h.DOG);
            return View(hISTORies.ToList());
        }

        // GET: History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORY hISTORY = db.HISTORies.Find(id);
            if (hISTORY == null)
            {
                return HttpNotFound();
            }
            return View(hISTORY);
        }

        // GET: History/Create
        public ActionResult Create()
        {
            ViewBag.DOG_ID = new SelectList(db.DOGs, "ID", "NAME");
            return View();
        }

        // POST: History/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DOG_ID,ADOPTER_NAME,HISTORY1,PICTURE")] HISTORY hISTORY, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/Content/img/history/" + ImageName);
                    file.SaveAs(physicalPath);
                    hISTORY.PICTURE = ImageName;

                }
                db.HISTORies.Add(hISTORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DOG_ID = new SelectList(db.DOGs, "ID", "NAME", hISTORY.DOG_ID);
            return View(hISTORY);
        }

        // GET: History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORY hISTORY = db.HISTORies.Find(id);
            if (hISTORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.DOG_ID = new SelectList(db.DOGs, "ID", "NAME", hISTORY.DOG_ID);
            return View(hISTORY);
        }

        // POST: History/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DOG_ID,ADOPTER_NAME,HISTORY1,PICTURE")] HISTORY hISTORY, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/Content/img/history/" + ImageName);
                    file.SaveAs(physicalPath);
                    hISTORY.PICTURE = ImageName;

                }
                db.Entry(hISTORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DOG_ID = new SelectList(db.DOGs, "ID", "NAME", hISTORY.DOG_ID);
            return View(hISTORY);
        }

        // GET: History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORY hISTORY = db.HISTORies.Find(id);
            if (hISTORY == null)
            {
                return HttpNotFound();
            }
            return View(hISTORY);
        }

        // POST: History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HISTORY hISTORY = db.HISTORies.Find(id);
            db.HISTORies.Remove(hISTORY);
            db.SaveChanges();
            return RedirectToAction("Index");
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

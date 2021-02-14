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
    public class BreedController : Controller
    {
        private adogmeEntities db = new adogmeEntities();

        // GET: Breed
        public ActionResult Index()
        {
            return View(db.BREEDs.ToList());
        }

        // GET: Breed/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BREED bREED = db.BREEDs.Find(id);
            if (bREED == null)
            {
                return HttpNotFound();
            }
            return View(bREED);
        }

        // GET: Breed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Breed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BREED1")] BREED bREED)
        {
            if (ModelState.IsValid)
            {
                db.BREEDs.Add(bREED);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bREED);
        }

        // GET: Breed/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BREED bREED = db.BREEDs.Find(id);
            if (bREED == null)
            {
                return HttpNotFound();
            }
            return View(bREED);
        }

        // POST: Breed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BREED1")] BREED bREED)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bREED).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bREED);
        }

        // GET: Breed/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BREED bREED = db.BREEDs.Find(id);
            if (bREED == null)
            {
                return HttpNotFound();
            }
            return View(bREED);
        }

        // POST: Breed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BREED bREED = db.BREEDs.Find(id);
            db.BREEDs.Remove(bREED);
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

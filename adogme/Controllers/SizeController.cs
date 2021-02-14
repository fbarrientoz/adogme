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
    public class SizeController : Controller
    {
        private adogmeEntities db = new adogmeEntities();

        // GET: Size
        public ActionResult Index()
        {
            return View(db.SIZEs.ToList());
        }

        // GET: Size/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIZE sIZE = db.SIZEs.Find(id);
            if (sIZE == null)
            {
                return HttpNotFound();
            }
            return View(sIZE);
        }

        // GET: Size/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Size/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SIZE1")] SIZE sIZE)
        {
            if (ModelState.IsValid)
            {
                db.SIZEs.Add(sIZE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sIZE);
        }

        // GET: Size/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIZE sIZE = db.SIZEs.Find(id);
            if (sIZE == null)
            {
                return HttpNotFound();
            }
            return View(sIZE);
        }

        // POST: Size/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SIZE1")] SIZE sIZE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sIZE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sIZE);
        }

        // GET: Size/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIZE sIZE = db.SIZEs.Find(id);
            if (sIZE == null)
            {
                return HttpNotFound();
            }
            return View(sIZE);
        }

        // POST: Size/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SIZE sIZE = db.SIZEs.Find(id);
            db.SIZEs.Remove(sIZE);
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

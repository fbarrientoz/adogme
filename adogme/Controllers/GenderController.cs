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
    public class GenderController : Controller
    {
        private adogmeEntities db = new adogmeEntities();

        // GET: Gender
        public ActionResult Index()
        {
            return View(db.GENDERs.ToList());
        }

        // GET: Gender/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENDER gENDER = db.GENDERs.Find(id);
            if (gENDER == null)
            {
                return HttpNotFound();
            }
            return View(gENDER);
        }

        // GET: Gender/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gender/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GENDER1")] GENDER gENDER)
        {
            if (ModelState.IsValid)
            {
                db.GENDERs.Add(gENDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gENDER);
        }

        // GET: Gender/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENDER gENDER = db.GENDERs.Find(id);
            if (gENDER == null)
            {
                return HttpNotFound();
            }
            return View(gENDER);
        }

        // POST: Gender/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GENDER1")] GENDER gENDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gENDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gENDER);
        }

        // GET: Gender/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENDER gENDER = db.GENDERs.Find(id);
            if (gENDER == null)
            {
                return HttpNotFound();
            }
            return View(gENDER);
        }

        // POST: Gender/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GENDER gENDER = db.GENDERs.Find(id);
            db.GENDERs.Remove(gENDER);
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

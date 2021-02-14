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
    public class AdoptionController : Controller
    {
        private adogmeEntities db = new adogmeEntities();

        // GET: Adoption
        public ActionResult Index()
        {
            var aDOPTIONs = db.ADOPTIONs.Include(a => a.DOG);
            return View(aDOPTIONs.ToList());
        }

        // GET: Adoption/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADOPTION aDOPTION = db.ADOPTIONs.Find(id);
            if (aDOPTION == null)
            {
                return HttpNotFound();
            }
            return View(aDOPTION);
        }

        // GET: Adoption/Create
        public ActionResult Create()
        {
            ViewBag.DOG_ID = new SelectList(db.DOGs, "ID", "NAME");
            return View();
        }

        // POST: Adoption/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FULL_NAME,EMAIL,DESCRIPTION,DOG_ID,REGISTER,ESTATUS")] ADOPTION aDOPTION)
        {
            if (ModelState.IsValid)
            {
                db.ADOPTIONs.Add(aDOPTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DOG_ID = new SelectList(db.DOGs, "ID", "NAME", aDOPTION.DOG_ID);
            return View(aDOPTION);
        }

        // GET: Adoption/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADOPTION aDOPTION = db.ADOPTIONs.Find(id);
            if (aDOPTION == null)
            {
                return HttpNotFound();
            }
            ViewBag.DOG_ID = new SelectList(db.DOGs, "ID", "NAME", aDOPTION.DOG_ID);
            return View(aDOPTION);
        }

        // POST: Adoption/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FULL_NAME,EMAIL,DESCRIPTION,DOG_ID,REGISTER,ESTATUS")] ADOPTION aDOPTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDOPTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DOG_ID = new SelectList(db.DOGs, "ID", "NAME", aDOPTION.DOG_ID);
            return View(aDOPTION);
        }

        // GET: Adoption/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADOPTION aDOPTION = db.ADOPTIONs.Find(id);
            if (aDOPTION == null)
            {
                return HttpNotFound();
            }
            return View(aDOPTION);
        }

        // POST: Adoption/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADOPTION aDOPTION = db.ADOPTIONs.Find(id);
            db.ADOPTIONs.Remove(aDOPTION);
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

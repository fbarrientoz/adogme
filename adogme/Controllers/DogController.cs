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
    public class DogController : Controller
    {
        private adogmeEntities db = new adogmeEntities();

        // GET: Dog
        public ActionResult Index()
        {
            var dOGs = db.DOGs.Include(d => d.BREED).Include(d => d.GENDER).Include(d => d.PLACE).Include(d => d.SIZE);
            return View(dOGs.ToList());
        }

        // GET: Dog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOG dOG = db.DOGs.Find(id);
            if (dOG == null)
            {
                return HttpNotFound();
            }
            return View(dOG);
        }

        // GET: Dog/Create
        public ActionResult Create()
        {
            ViewBag.BREED_ID = new SelectList(db.BREEDs, "ID", "BREED1");
            ViewBag.GENDER_ID = new SelectList(db.GENDERs, "ID", "GENDER1");
            ViewBag.PLACE_ID = new SelectList(db.PLACEs, "ID", "PLACE1");
            ViewBag.SIZE_ID = new SelectList(db.SIZEs, "ID", "SIZE1");
            return View();
        }

        // POST: Dog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,CITY,BREED_ID,GENDER_ID,SIZE_ID,PLACE_ID,IS_ADOPTED,REGISTER,PICTURE,AGE")] DOG dOG)
        {
            if (ModelState.IsValid)
            {
                db.DOGs.Add(dOG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BREED_ID = new SelectList(db.BREEDs, "ID", "BREED1", dOG.BREED_ID);
            ViewBag.GENDER_ID = new SelectList(db.GENDERs, "ID", "GENDER1", dOG.GENDER_ID);
            ViewBag.PLACE_ID = new SelectList(db.PLACEs, "ID", "PLACE1", dOG.PLACE_ID);
            ViewBag.SIZE_ID = new SelectList(db.SIZEs, "ID", "SIZE1", dOG.SIZE_ID);
            return View(dOG);
        }

        // GET: Dog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOG dOG = db.DOGs.Find(id);
            if (dOG == null)
            {
                return HttpNotFound();
            }
            ViewBag.BREED_ID = new SelectList(db.BREEDs, "ID", "BREED1", dOG.BREED_ID);
            ViewBag.GENDER_ID = new SelectList(db.GENDERs, "ID", "GENDER1", dOG.GENDER_ID);
            ViewBag.PLACE_ID = new SelectList(db.PLACEs, "ID", "PLACE1", dOG.PLACE_ID);
            ViewBag.SIZE_ID = new SelectList(db.SIZEs, "ID", "SIZE1", dOG.SIZE_ID);
            return View(dOG);
        }

        // POST: Dog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,CITY,BREED_ID,GENDER_ID,SIZE_ID,PLACE_ID,IS_ADOPTED,REGISTER,PICTURE,AGE")] DOG dOG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BREED_ID = new SelectList(db.BREEDs, "ID", "BREED1", dOG.BREED_ID);
            ViewBag.GENDER_ID = new SelectList(db.GENDERs, "ID", "GENDER1", dOG.GENDER_ID);
            ViewBag.PLACE_ID = new SelectList(db.PLACEs, "ID", "PLACE1", dOG.PLACE_ID);
            ViewBag.SIZE_ID = new SelectList(db.SIZEs, "ID", "SIZE1", dOG.SIZE_ID);
            return View(dOG);
        }

        // GET: Dog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOG dOG = db.DOGs.Find(id);
            if (dOG == null)
            {
                return HttpNotFound();
            }
            return View(dOG);
        }

        // POST: Dog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOG dOG = db.DOGs.Find(id);
            db.DOGs.Remove(dOG);
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

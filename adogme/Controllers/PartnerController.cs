﻿using System;
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
    public class PartnerController : Controller
    {
        private adogmeEntities db = new adogmeEntities();

        // GET: Partner
        public ActionResult Index()
        {
            return View(db.PARTNERS.ToList());
        }

        // GET: Partner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTNER pARTNER = db.PARTNERS.Find(id);
            if (pARTNER == null)
            {
                return HttpNotFound();
            }
            return View(pARTNER);
        }

        // GET: Partner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partner/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,DESCRIPTION,PICTURE")] PARTNER pARTNER, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/Content/img/partner/" + ImageName);
                    file.SaveAs(physicalPath);
                    pARTNER.PICTURE = ImageName;

                }
                db.PARTNERS.Add(pARTNER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pARTNER);
        }

        // GET: Partner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTNER pARTNER = db.PARTNERS.Find(id);
            if (pARTNER == null)
            {
                return HttpNotFound();
            }
            return View(pARTNER);
        }

        // POST: Partner/Edit/5
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,DESCRIPTION,PICTURE")] PARTNER pARTNER ,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/Content/img/partner/" + ImageName);
                    file.SaveAs(physicalPath);
                    pARTNER.PICTURE = ImageName;

                }
                db.Entry(pARTNER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pARTNER);
        }

        // GET: Partner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTNER pARTNER = db.PARTNERS.Find(id);
            if (pARTNER == null)
            {
                return HttpNotFound();
            }
            return View(pARTNER);
        }

        // POST: Partner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PARTNER pARTNER = db.PARTNERS.Find(id);
            db.PARTNERS.Remove(pARTNER);
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

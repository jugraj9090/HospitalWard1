using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalWard.Models;

namespace HospitalWard.Controllers
{
    public class WardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wards
        public ActionResult Index()
        {
            var wardList = db.WardList.Include(w => w.Doctor).Include(w => w.Nurse);
            return View(wardList.ToList());
        }

        // GET: Wards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ward ward = db.WardList.Find(id);
            if (ward == null)
            {
                return HttpNotFound();
            }
            return View(ward);
        }

        // GET: Wards/Create
        public ActionResult Create()
        {
            ViewBag.DoctorID = new SelectList(db.DoctorList, "ID", "DoctorName");
            ViewBag.NurseID = new SelectList(db.NurseList, "ID", "NurseName");
            return View();
        }

        // POST: Wards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Location,NurseID,DoctorID")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                db.WardList.Add(ward);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorID = new SelectList(db.DoctorList, "ID", "DoctorName", ward.DoctorID);
            ViewBag.NurseID = new SelectList(db.NurseList, "ID", "NurseName", ward.NurseID);
            return View(ward);
        }

        // GET: Wards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ward ward = db.WardList.Find(id);
            if (ward == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorID = new SelectList(db.DoctorList, "ID", "DoctorName", ward.DoctorID);
            ViewBag.NurseID = new SelectList(db.NurseList, "ID", "NurseName", ward.NurseID);
            return View(ward);
        }

        // POST: Wards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Location,NurseID,DoctorID")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ward).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorID = new SelectList(db.DoctorList, "ID", "DoctorName", ward.DoctorID);
            ViewBag.NurseID = new SelectList(db.NurseList, "ID", "NurseName", ward.NurseID);
            return View(ward);
        }

        // GET: Wards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ward ward = db.WardList.Find(id);
            if (ward == null)
            {
                return HttpNotFound();
            }
            return View(ward);
        }

        // POST: Wards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ward ward = db.WardList.Find(id);
            db.WardList.Remove(ward);
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

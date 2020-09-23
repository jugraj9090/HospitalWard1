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
    public class NursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Nurses
        public ActionResult Index()
        {
            return View(db.NurseList.ToList());
        }

        // GET: Nurses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse nurse = db.NurseList.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();
            }
            return View(nurse);
        }

        // GET: Nurses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nurses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NurseName,Specialty")] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                db.NurseList.Add(nurse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nurse);
        }

        // GET: Nurses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse nurse = db.NurseList.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();
            }
            return View(nurse);
        }

        // POST: Nurses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NurseName,Specialty")] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nurse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nurse);
        }

        // GET: Nurses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse nurse = db.NurseList.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();
            }
            return View(nurse);
        }

        // POST: Nurses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nurse nurse = db.NurseList.Find(id);
            db.NurseList.Remove(nurse);
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

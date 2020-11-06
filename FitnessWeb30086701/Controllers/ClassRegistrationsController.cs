using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessWeb30086701.Models;

namespace FitnessWeb30086701.Controllers
{
    public class ClassRegistrationsController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: ClassRegistrations
        public ActionResult Index()
        {
            var classRegistrations = db.ClassRegistrations.Include(c => c.Class);
            return View(classRegistrations.ToList());
        }

        // GET: ClassRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRegistration classRegistration = db.ClassRegistrations.Find(id);
            if (classRegistration == null)
            {
                return HttpNotFound();
            }
            return View(classRegistration);
        }

        // GET: ClassRegistrations/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "ClassName");
            return View();
        }

        // POST: ClassRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,DOB,Email,Address,ClassId,UserId")] ClassRegistration classRegistration)
        {
            if (ModelState.IsValid)
            {
                db.ClassRegistrations.Add(classRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "Id", "ClassName", classRegistration.ClassId);
            return View(classRegistration);
        }

        // GET: ClassRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRegistration classRegistration = db.ClassRegistrations.Find(id);
            if (classRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "ClassName", classRegistration.ClassId);
            return View(classRegistration);
        }

        // POST: ClassRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,DOB,Email,Address,ClassId,UserId")] ClassRegistration classRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "ClassName", classRegistration.ClassId);
            return View(classRegistration);
        }

        // GET: ClassRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRegistration classRegistration = db.ClassRegistrations.Find(id);
            if (classRegistration == null)
            {
                return HttpNotFound();
            }
            return View(classRegistration);
        }

        // POST: ClassRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassRegistration classRegistration = db.ClassRegistrations.Find(id);
            db.ClassRegistrations.Remove(classRegistration);
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

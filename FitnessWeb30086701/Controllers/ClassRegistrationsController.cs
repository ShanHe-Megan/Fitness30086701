using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessWeb30086701.Models;
using Microsoft.AspNet.Identity;

namespace FitnessWeb30086701.Controllers
{
    [Authorize]
    public class ClassRegistrationsController : Controller
    {
        private Entities db = new Entities();
        // GET: ClassRegistrations
        public ActionResult Index1()
        {
            var classRegistrations = db.ClassRegistrations.Include(c => c.Class);
            string currentUserId = User.Identity.GetUserId();
            return View(db.ClassRegistrations.Where(m => m.UserId ==
           currentUserId).ToList());
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Index2()
        {
            var classRegistrations = db.ClassRegistrations.Include(c => c.Class);
            return View(db.ClassRegistrations.ToList());
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
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,DOB,Email,Address,ClassId")] ClassRegistration classRegistration)
        {
            classRegistration.UserId = User.Identity.GetUserId();
            classRegistration.Id = db.ClassRegistrations.Count() + 1;
                db.ClassRegistrations.Add(classRegistration);
                db.SaveChanges();
                return RedirectToAction("Index1");

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
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,DOB,Email,Address,ClassId")] ClassRegistration classRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index2");
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
            return RedirectToAction("Index2");
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

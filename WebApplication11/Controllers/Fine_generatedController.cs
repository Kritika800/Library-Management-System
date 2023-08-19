using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class Fine_generatedController : Controller
    {
        private LibraryManagemntsystemEntities3 db = new LibraryManagemntsystemEntities3();

        // GET: Fine_generated
        public ActionResult Index()
        {
            return View(db.Fine_generated.ToList());
        }

        // GET: Fine_generated/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fine_generated fine_generated = db.Fine_generated.Find(id);
            if (fine_generated == null)
            {
                return HttpNotFound();
            }
            return View(fine_generated);
        }

        // GET: Fine_generated/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fine_generated/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FineId,BookName,Fine_Charged,Dateofissue,Dateofreturn,Original_Dateofreturn")] Fine_generated fine_generated)
        {
            if (ModelState.IsValid)
            {
                db.Fine_generated.Add(fine_generated);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fine_generated);
        }

        // GET: Fine_generated/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fine_generated fine_generated = db.Fine_generated.Find(id);
            if (fine_generated == null)
            {
                return HttpNotFound();
            }
            return View(fine_generated);
        }

        // POST: Fine_generated/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FineId,BookName,Fine_Charged,Dateofissue,Dateofreturn,Original_Dateofreturn")] Fine_generated fine_generated)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fine_generated).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fine_generated);
        }

        // GET: Fine_generated/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fine_generated fine_generated = db.Fine_generated.Find(id);
            if (fine_generated == null)
            {
                return HttpNotFound();
            }
            return View(fine_generated);
        }

        // POST: Fine_generated/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fine_generated fine_generated = db.Fine_generated.Find(id);
            db.Fine_generated.Remove(fine_generated);
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

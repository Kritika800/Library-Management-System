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
    public class NewBookCollectionsController : Controller
    {
        private LibraryManagemntsystemEntities3 db = new LibraryManagemntsystemEntities3();

        // GET: NewBookCollections
        public ActionResult Index()
        {
            return View(db.NewBookCollections.ToList());
        }

        // GET: NewBookCollections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewBookCollection newBookCollection = db.NewBookCollections.Find(id);
            if (newBookCollection == null)
            {
                return HttpNotFound();
            }
            return View(newBookCollection);
        }

        // GET: NewBookCollections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewBookCollections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NAME")] NewBookCollection newBookCollection)
        {
            if (ModelState.IsValid)
            {
                db.NewBookCollections.Add(newBookCollection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newBookCollection);
        }

        // GET: NewBookCollections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewBookCollection newBookCollection = db.NewBookCollections.Find(id);
            if (newBookCollection == null)
            {
                return HttpNotFound();
            }
            return View(newBookCollection);
        }

        // POST: NewBookCollections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NAME")] NewBookCollection newBookCollection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newBookCollection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newBookCollection);
        }

        // GET: NewBookCollections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewBookCollection newBookCollection = db.NewBookCollections.Find(id);
            if (newBookCollection == null)
            {
                return HttpNotFound();
            }
            return View(newBookCollection);
        }

        // POST: NewBookCollections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewBookCollection newBookCollection = db.NewBookCollections.Find(id);
            db.NewBookCollections.Remove(newBookCollection);
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

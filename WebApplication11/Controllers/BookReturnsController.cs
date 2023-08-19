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
    public class BookReturnsController : Controller
    {
        private LibraryManagemntsystemEntities3 db = new LibraryManagemntsystemEntities3();

        // GET: BookReturns
        public ActionResult Index()
        {
            return View(db.BookReturns.ToList());
        }

        // GET: BookReturns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookReturn bookReturn = db.BookReturns.Find(id);
            if (bookReturn == null)
            {
                return HttpNotFound();
            }
            return View(bookReturn);
        }

        // GET: BookReturns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookReturns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookName,Returndate,issuedate")] BookReturn bookReturn)
        {
            if (ModelState.IsValid)
            {
                db.BookReturns.Add(bookReturn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookReturn);
        }

        // GET: BookReturns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookReturn bookReturn = db.BookReturns.Find(id);
            if (bookReturn == null)
            {
                return HttpNotFound();
            }
            return View(bookReturn);
        }

        // POST: BookReturns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookName,Returndate,issuedate")] BookReturn bookReturn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookReturn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookReturn);
        }

        // GET: BookReturns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookReturn bookReturn = db.BookReturns.Find(id);
            if (bookReturn == null)
            {
                return HttpNotFound();
            }
            return View(bookReturn);
        }

        // POST: BookReturns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookReturn bookReturn = db.BookReturns.Find(id);
            db.BookReturns.Remove(bookReturn);
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

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
    public class Purchase_HistoryController : Controller
    {
        private LibraryManagemntsystemEntities3 db = new LibraryManagemntsystemEntities3();

        // GET: Purchase_History
        public ActionResult Index()
        {
            return View(db.Purchase_Histories.ToList());
        }

        // GET: Purchase_History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_History purchase_History = db.Purchase_Histories.Find(id);
            if (purchase_History == null)
            {
                return HttpNotFound();
            }
            return View(purchase_History);
        }

        // GET: Purchase_History/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Purchase_History/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,BookName")] Purchase_History purchase_History)
        {
            if (ModelState.IsValid)
            {
                db.Purchase_Histories.Add(purchase_History);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchase_History);
        }

        // GET: Purchase_History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_History purchase_History = db.Purchase_Histories.Find(id);
            if (purchase_History == null)
            {
                return HttpNotFound();
            }
            return View(purchase_History);
        }

        // POST: Purchase_History/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,BookName")] Purchase_History purchase_History)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase_History).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchase_History);
        }

        // GET: Purchase_History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_History purchase_History = db.Purchase_Histories.Find(id);
            if (purchase_History == null)
            {
                return HttpNotFound();
            }
            return View(purchase_History);
        }

        // POST: Purchase_History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase_History purchase_History = db.Purchase_Histories.Find(id);
            db.Purchase_Histories.Remove(purchase_History);
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

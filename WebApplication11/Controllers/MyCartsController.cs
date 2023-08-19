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
    public class MyCartsController : Controller
    {
        private LibraryManagemntsystemEntities3 db = new LibraryManagemntsystemEntities3();

        // GET: MyCarts
        public ActionResult Index()
        {
            return View(db.MyCarts.ToList());
        }

        // GET: MyCarts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCart myCart = db.MyCarts.Find(id);
            if (myCart == null)
            {
                return HttpNotFound();
            }
            return View(myCart);
        }

        // GET: MyCarts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,BookName,DATE_OF_ISSUE,DATE_OF_RETURN")] MyCart myCart)
        {
            if (ModelState.IsValid)
            {
                db.MyCarts.Add(myCart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myCart);
        }

        // GET: MyCarts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCart myCart = db.MyCarts.Find(id);
            if (myCart == null)
            {
                return HttpNotFound();
            }
            return View(myCart);
        }

        // POST: MyCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,BookName,DATE_OF_ISSUE,DATE_OF_RETURN")] MyCart myCart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myCart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myCart);
        }

        // GET: MyCarts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCart myCart = db.MyCarts.Find(id);
            if (myCart == null)
            {
                return HttpNotFound();
            }
            return View(myCart);
        }

        // POST: MyCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyCart myCart = db.MyCarts.Find(id);
            db.MyCarts.Remove(myCart);
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

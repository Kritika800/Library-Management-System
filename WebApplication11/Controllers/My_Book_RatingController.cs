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
    public class My_Book_RatingController : Controller
    {
        private LibraryManagemntsystemEntities3 db = new LibraryManagemntsystemEntities3();

        // GET: My_Book_Rating
        public ActionResult Index()
        {
            return View(db.My_Book_Ratings.ToList());
        }

        // GET: My_Book_Rating/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            My_Book_Rating my_Book_Rating = db.My_Book_Ratings.Find(id);
            if (my_Book_Rating == null)
            {
                return HttpNotFound();
            }
            return View(my_Book_Rating);
        }

        // GET: My_Book_Rating/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: My_Book_Rating/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Name,Feedback")] My_Book_Rating my_Book_Rating)
        {
            if (ModelState.IsValid)
            {
                db.My_Book_Ratings.Add(my_Book_Rating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(my_Book_Rating);
        }

        // GET: My_Book_Rating/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            My_Book_Rating my_Book_Rating = db.My_Book_Ratings.Find(id);
            if (my_Book_Rating == null)
            {
                return HttpNotFound();
            }
            return View(my_Book_Rating);
        }

        // POST: My_Book_Rating/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Name,Feedback")] My_Book_Rating my_Book_Rating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(my_Book_Rating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(my_Book_Rating);
        }

        // GET: My_Book_Rating/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            My_Book_Rating my_Book_Rating = db.My_Book_Ratings.Find(id);
            if (my_Book_Rating == null)
            {
                return HttpNotFound();
            }
            return View(my_Book_Rating);
        }

        // POST: My_Book_Rating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            My_Book_Rating my_Book_Rating = db.My_Book_Ratings.Find(id);
            db.My_Book_Ratings.Remove(my_Book_Rating);
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

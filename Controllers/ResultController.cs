using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pto_restful_service.Models;

namespace pto_restful_service.Controllers
{
    public class ResultController : Controller
    {
        private entities db = new entities();

        // GET: Result
        public ActionResult Index()
        {
            return View(db.test_result.ToList());
        }

        // GET: Result/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test_result test_result = db.test_result.Find(id);
            if (test_result == null)
            {
                return HttpNotFound();
            }
            return View(test_result);
        }

        // GET: Result/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Result/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date_create,gmail,test_name,personality")] test_result test_result)
        {
            if (ModelState.IsValid)
            {
                db.test_result.Add(test_result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test_result);
        }

        // GET: Result/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test_result test_result = db.test_result.Find(id);
            if (test_result == null)
            {
                return HttpNotFound();
            }
            return View(test_result);
        }

        // POST: Result/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date_create,gmail,test_name,personality")] test_result test_result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test_result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test_result);
        }

        // GET: Result/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test_result test_result = db.test_result.Find(id);
            if (test_result == null)
            {
                return HttpNotFound();
            }
            return View(test_result);
        }

        // POST: Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            test_result test_result = db.test_result.Find(id);
            db.test_result.Remove(test_result);
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

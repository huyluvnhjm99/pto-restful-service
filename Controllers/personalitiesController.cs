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
    public class PersonalitiesController : Controller
    {
        private entities db = new entities();

        // GET: Personalities
        public ActionResult Index()
        {
            return View(db.personalities.ToList());
        }

        // GET: Personalities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personality personality = db.personalities.Find(id);
            if (personality == null)
            {
                return HttpNotFound();
            }
            return View(personality);
        }

        // GET: Personalities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personalities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,description")] personality personality)
        {
            if (ModelState.IsValid)
            {
                db.personalities.Add(personality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personality);
        }

        // GET: Personalities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personality personality = db.personalities.Find(id);
            if (personality == null)
            {
                return HttpNotFound();
            }
            return View(personality);
        }

        // POST: Personalities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,description")] personality personality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personality);
        }

        // GET: Personalities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personality personality = db.personalities.Find(id);
            if (personality == null)
            {
                return HttpNotFound();
            }
            return View(personality);
        }

        // POST: Personalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personality personality = db.personalities.Find(id);
            db.personalities.Remove(personality);
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

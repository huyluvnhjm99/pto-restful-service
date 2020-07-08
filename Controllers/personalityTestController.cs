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
    public class PersonalityTestController : Controller
    {
        private entities db = new entities();

        // GET: PersonalityTest
        public ActionResult Index()
        {
            return View(db.personality_test.ToList());
        }

        // GET: PersonalityTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personality_test personality_test = db.personality_test.Find(id);
            if (personality_test == null)
            {
                return HttpNotFound();
            }
            return View(personality_test);
        }

        // GET: PersonalityTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalityTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,description,image")] personality_test personality_test)
        {
            if (ModelState.IsValid)
            {
                db.personality_test.Add(personality_test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personality_test);
        }

        // GET: PersonalityTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personality_test personality_test = db.personality_test.Find(id);
            if (personality_test == null)
            {
                return HttpNotFound();
            }
            return View(personality_test);
        }

        // POST: PersonalityTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,description,image")] personality_test personality_test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personality_test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personality_test);
        }

        // GET: PersonalityTest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personality_test personality_test = db.personality_test.Find(id);
            if (personality_test == null)
            {
                return HttpNotFound();
            }
            return View(personality_test);
        }

        // POST: PersonalityTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personality_test personality_test = db.personality_test.Find(id);
            db.personality_test.Remove(personality_test);
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

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
    public class UserAnswersController : Controller
    {
        private entities db = new entities();

        // GET: UserAnswers
        public ActionResult Index()
        {
            return View(db.user_answer.ToList());
        }

        // GET: UserAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_answer user_answer = db.user_answer.Find(id);
            if (user_answer == null)
            {
                return HttpNotFound();
            }
            return View(user_answer);
        }

        // GET: UserAnswers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,result_id,question_id,answer_id")] user_answer user_answer)
        {
            if (ModelState.IsValid)
            {
                db.user_answer.Add(user_answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_answer);
        }

        // GET: UserAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_answer user_answer = db.user_answer.Find(id);
            if (user_answer == null)
            {
                return HttpNotFound();
            }
            return View(user_answer);
        }

        // POST: UserAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,result_id,question_id,answer_id")] user_answer user_answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_answer);
        }

        // GET: UserAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_answer user_answer = db.user_answer.Find(id);
            if (user_answer == null)
            {
                return HttpNotFound();
            }
            return View(user_answer);
        }

        // POST: UserAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_answer user_answer = db.user_answer.Find(id);
            db.user_answer.Remove(user_answer);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using pto_restful_service.Models;

namespace pto_restful_service.Controllers
{
    public class questionsController : ApiController
    {
        private entities db = new entities();

        // GET: api/questions
        public IQueryable<question> Getquestions()
        {
            return db.questions;
        }

        public IQueryable<question> Getquestions(int test_id)
        {
            return db.questions.Where(e => e.test_id == test_id);
        }

        // GET: api/questions/5
        [ResponseType(typeof(question))]
        public IHttpActionResult Getquestion(int id)
        {
            question question = db.questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // PUT: api/questions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putquestion(int id, question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != question.id)
            {
                return BadRequest();
            }

            db.Entry(question).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!questionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/questions
        [ResponseType(typeof(question))]
        public IHttpActionResult Postquestion(question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.questions.Add(question);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = question.id }, question);
        }

        // DELETE: api/questions/5
        [ResponseType(typeof(question))]
        public IHttpActionResult Deletequestion(int id)
        {
            question question = db.questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            db.questions.Remove(question);
            db.SaveChanges();

            return Ok(question);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool questionExists(int id)
        {
            return db.questions.Count(e => e.id == id) > 0;
        }
    }
}
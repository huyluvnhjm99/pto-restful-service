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
using pto_restful_service.Models;

namespace pto_restful_service.Controllers
{
    public class useranswerController : ApiController
    {
        private entities db = new entities();

        [ActionName("get-all")]
        // GET: api/useranswer
        public IQueryable<user_answer> Getuser_answer()
        {
            return db.user_answer;
        }

        [ActionName("get-by-id")]
        // GET: api/useranswer/5
        [ResponseType(typeof(user_answer))]
        public IHttpActionResult Getuser_answer(int id)
        {
            user_answer user_answer = db.user_answer.Find(id);
            if (user_answer == null)
            {
                return NotFound();
            }

            return Ok(user_answer);
        }

        [ActionName("put-useranswer")]
        // PUT: api/useranswer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putuser_answer(int id, user_answer user_answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_answer.id)
            {
                return BadRequest();
            }

            db.Entry(user_answer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!user_answerExists(id))
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

        [ActionName("post-useranswer")]
        // POST: api/useranswer
        [ResponseType(typeof(user_answer))]
        public IHttpActionResult Postuser_answer(user_answer user_answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.user_answer.Add(user_answer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (user_answerExists(user_answer.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user_answer.id }, user_answer);
        }

        [ActionName("delete-by-id")]
        // DELETE: api/useranswer/5
        [ResponseType(typeof(user_answer))]
        public IHttpActionResult Deleteuser_answer(int id)
        {
            user_answer user_answer = db.user_answer.Find(id);
            if (user_answer == null)
            {
                return NotFound();
            }

            db.user_answer.Remove(user_answer);
            db.SaveChanges();

            return Ok(user_answer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool user_answerExists(int id)
        {
            return db.user_answer.Count(e => e.id == id) > 0;
        }
    }
}
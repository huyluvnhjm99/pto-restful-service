﻿using System;
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
    [RoutePrefix("api/v1/answers")]
    public class answersController : ApiController
    {
        private entities db = new entities();

        // GET: api/answers
        public IQueryable<answer> Getanswers()
        {
            return db.answers;
        }

        // GET: api/answers/5
        [ResponseType(typeof(answer))]
        public IHttpActionResult Getanswer(int id)
        {
            answer answer = db.answers.Find(id);
            if (answer == null)
            {
                return NotFound();
            }

            return Ok(answer);
        }

        [Route("filter")]
        public IQueryable<answer> GetanswersByFilter(string min, string max, bool isSort)
        {
            if (isSort)
            {
                return db.answers.Where(e => e.answer_content.CompareTo(min) >= 0
                && e.answer_content.CompareTo(max) <= 0).OrderBy(e => e.answer_content);
            }
            else
            {
                return db.answers.Where(e => e.answer_content.CompareTo(min) >= 0
                && e.answer_content.CompareTo(max) <= 0);
            }
        }

        [Route("question-id/{id}")]
        //.../api/v1/questions?test_id=1&isSort=true
        public IQueryable<answer> GetanswersByQuestionIdAndSort(int id, bool isSort)
        {
            if (isSort)
            {
                return db.answers.Where(e => e.question_id == id).OrderBy(e => e.answer_content);
            }
            else
            {
                return db.answers.Where(e => e.question_id == id);
            }
        }


        //u[ActionName("put-answer")]
        // PUT: api/answers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putanswer(int id, answer answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answer.id)
            {
                return BadRequest();
            }

            db.Entry(answer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!answerExists(id))
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
        //[ActionName("post-answer")]
        // POST: api/answers
        [ResponseType(typeof(answer))]
        public IHttpActionResult Postanswer(answer answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.answers.Add(answer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = answer.id }, answer);
        }
        //[ActionName("delete-answer")]
        // DELETE: api/answers/5
        [ResponseType(typeof(answer))]
        public IHttpActionResult Deleteanswer(int id)
        {
            answer answer = db.answers.Find(id);
            if (answer == null)
            {
                return NotFound();
            }

            db.answers.Remove(answer);
            db.SaveChanges();

            return Ok(answer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool answerExists(int id)
        {
            return db.answers.Count(e => e.id == id) > 0;
        }
    }
}
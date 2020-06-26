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
    [RoutePrefix("api/test-result")]
    public class testresultController : ApiController
    {
        private entities db = new entities();

        //[ActionName("get-all")]
        // GET: api/testresult'
        [Route("")]
        public IQueryable<test_result> Gettest_result()
        {
            return db.test_result;
        }

        //[ActionName("get-by-id")]
        [Route("{id}")]
        // GET: api/testresult/5
        [ResponseType(typeof(test_result))]
        public IHttpActionResult Gettest_result(int id)
        {
            test_result test_result = db.test_result.Find(id);
            if (test_result == null)
            {
                return NotFound();
            }

            return Ok(test_result);
        }

        //[ActionName("put-result")]
        // PUT: api/testresult/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttest_result(int id, test_result test_result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test_result.id)
            {
                return BadRequest();
            }

            db.Entry(test_result).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!test_resultExists(id))
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

        //[ActionName("post-result")]
        // POST: api/testresult
        [Route("")]
        [ResponseType(typeof(test_result))]
        public IHttpActionResult Posttest_result(test_result test_result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.test_result.Add(test_result);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (test_resultExists(test_result.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = test_result.id }, test_result);
        }

        //[ActionName("delete-result")]
        // DELETE: api/testresult/5
        [Route("{id}")]
        [ResponseType(typeof(test_result))]
        public IHttpActionResult Deletetest_result(int id)
        {
            test_result test_result = db.test_result.Find(id);
            if (test_result == null)
            {
                return NotFound();
            }

            db.test_result.Remove(test_result);
            db.SaveChanges();

            return Ok(test_result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool test_resultExists(int id)
        {
            return db.test_result.Count(e => e.id == id) > 0;
        }
    }
}
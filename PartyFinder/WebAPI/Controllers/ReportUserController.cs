using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ReportUserController : ApiController
    {
        private PartyFinderContext db = new PartyFinderContext();

        // GET: api/ReportUser
        public IQueryable<ReportUser> GetReportUser()
        {
            return db.ReportUser;
        }

        // GET: api/ReportUser/5
        [ResponseType(typeof(ReportUser))]
        public async Task<IHttpActionResult> GetReportUser(int id)
        {
            ReportUser reportUser = await db.ReportUser.FindAsync(id);
            if (reportUser == null)
            {
                return NotFound();
            }

            return Ok(reportUser);
        }

        // PUT: api/ReportUser/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReportUser(int id, ReportUser reportUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reportUser.ID)
            {
                return BadRequest();
            }

            db.Entry(reportUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportUserExists(id))
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

        // POST: api/ReportUser
        [ResponseType(typeof(ReportUser))]
        public async Task<IHttpActionResult> PostReportUser(ReportUser reportUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReportUser.Add(reportUser);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reportUser.ID }, reportUser);
        }

        // DELETE: api/ReportUser/5
        [ResponseType(typeof(ReportUser))]
        public async Task<IHttpActionResult> DeleteReportUser(int id)
        {
            ReportUser reportUser = await db.ReportUser.FindAsync(id);
            if (reportUser == null)
            {
                return NotFound();
            }

            db.ReportUser.Remove(reportUser);
            await db.SaveChangesAsync();

            return Ok(reportUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReportUserExists(int id)
        {
            return db.ReportUser.Count(e => e.ID == id) > 0;
        }
    }
}
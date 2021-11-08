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
    public class BusinessController : ApiController
    {
        private PartyFinderContext db = new PartyFinderContext();

        // GET: api/Businesses
        public IQueryable<Business> GetBusiness()
        {
            return db.Business;
        }

        // GET: api/Businesses/5
        [ResponseType(typeof(Business))]
        public async Task<IHttpActionResult> GetBusiness(int id)
        {
            Business business = await db.Business.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }

            return Ok(business);
        }

        // PUT: api/Businesses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBusiness(int id, Business business)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != business.ProfileID)
            {
                return BadRequest();
            }

            db.Entry(business).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(id))
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

        // POST: api/Businesses
        [ResponseType(typeof(Business))]
        public async Task<IHttpActionResult> PostBusiness(Business business)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Business.Add(business);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BusinessExists(business.ProfileID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = business.ProfileID }, business);
        }

        // DELETE: api/Businesses/5
        [ResponseType(typeof(Business))]
        public async Task<IHttpActionResult> DeleteBusiness(int id)
        {
            Business business = await db.Business.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }

            db.Business.Remove(business);
            await db.SaveChangesAsync();

            return Ok(business);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusinessExists(int id)
        {
            return db.Business.Count(e => e.ProfileID == id) > 0;
        }
    }
}
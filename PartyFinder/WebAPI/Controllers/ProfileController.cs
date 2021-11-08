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
    public class ProfileController : ApiController
    {
        private PartyFinderContext db = new PartyFinderContext();

        // GET: api/Profile
        public IQueryable<Profile> GetProfile()
        {
            return db.Profile;
        }

        // GET: api/Profile/5
        [ResponseType(typeof(Profile))]
        public async Task<IHttpActionResult> GetProfile(int id)
        {
            Profile profile = await db.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/Profile/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProfile(int id, Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.ID)
            {
                return BadRequest();
            }

            db.Entry(profile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        // POST: api/Profile
        [ResponseType(typeof(Profile))]
        public async Task<IHttpActionResult> PostProfile(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profile.Add(profile);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = profile.ID }, profile);
        }

        // DELETE: api/Profile/5
        [ResponseType(typeof(Profile))]
        public async Task<IHttpActionResult> DeleteProfile(int id)
        {
            Profile profile = await db.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            db.Profile.Remove(profile);
            await db.SaveChangesAsync();

            return Ok(profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfileExists(int id)
        {
            return db.Profile.Count(e => e.ID == id) > 0;
        }
    }
}
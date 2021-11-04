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
    public class EventController : ApiController
    {
        private PartyFinderContext db = new PartyFinderContext();

        // GET: api/Event
        public IQueryable<Event> GetEvent()
        {
            return db.Event;
        }

        // GET: api/Event/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> GetEvent(int id)
        {
            Event @event = await db.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Event/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEvent(int id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.ID)
            {
                return BadRequest();
            }

            db.Entry(@event).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Event
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> PostEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Event.Add(@event);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = @event.ID }, @event);
        }

        // DELETE: api/Event/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> DeleteEvent(int id)
        {
            Event @event = await db.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Event.Remove(@event);
            await db.SaveChangesAsync();

            return Ok(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.Event.Count(e => e.ID == id) > 0;
        }
    }
}
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
    public class ChatController : ApiController
    {
        private PartyFinderContext db = new PartyFinderContext();

        // GET: api/Chats
        public IQueryable<Chat> GetChat()
        {
            return db.Chat;
        }

        // GET: api/Chats/5
        [ResponseType(typeof(Chat))]
        public async Task<IHttpActionResult> GetChat(int id)
        {
            Chat chat = await db.Chat.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            return Ok(chat);
        }

        // PUT: api/Chats/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChat(int id, Chat chat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chat.ID)
            {
                return BadRequest();
            }

            db.Entry(chat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatExists(id))
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

        // POST: api/Chats
        [ResponseType(typeof(Chat))]
        public async Task<IHttpActionResult> PostChat(Chat chat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Chat.Add(chat);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = chat.ID }, chat);
        }

        // DELETE: api/Chats/5
        [ResponseType(typeof(Chat))]
        public async Task<IHttpActionResult> DeleteChat(int id)
        {
            Chat chat = await db.Chat.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            db.Chat.Remove(chat);
            await db.SaveChangesAsync();

            return Ok(chat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatExists(int id)
        {
            return db.Chat.Count(e => e.ID == id) > 0;
        }
    }
}
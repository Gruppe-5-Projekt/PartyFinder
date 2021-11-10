using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.DAL
{
    public class EventDBAccess : IEventDBAccess
    {
        public List<Event> GetAllEvents()
        {
            using (var ctx = new PartyFinderContext())
            {
                var eventList = ctx.Event
                    .Select(e => e.EventName);

                return (List<Event>)eventList;
            }
        }
    }
}
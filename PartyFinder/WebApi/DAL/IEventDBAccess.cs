using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DAL
{
    interface IEventDBAccess
    {
        List<Event> GetAllEvents();
    }
}

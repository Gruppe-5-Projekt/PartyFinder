using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using WebApi.Models;
using WebApi.DAL;

namespace WebApi.Tests
{
    [TestClass]
    public class EventUnitTest
    {

        public void TestGetAllEvents()
        {
            // Arrange

            // Act
            List<Event> readEvents = EventDBAccess.GetAllEvents();
            bool eventsWereRead = (readEvents.Count > 0);
            // print additional output
            Console.WriteLine("Number of events: " + readEvents.Count);
            // Assert
            Assert.IsTrue(eventsWereRead);
        }
    }
}

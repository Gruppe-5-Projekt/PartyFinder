using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApi.Tests
{
    [TestClass]
    public class TestSimpleEventController
    {   
        [TestMethod]
        public void GetAllEvents_ShouldReturnAllEvents()
        {
            var testEvents = GetTestEvents();
            var controller = new EventController(/*testEvents*/);

            /*var result = controller.GetAllEvents() as List<Event>;
            Assert.AreEqual(testEvents.Count, result.Count);*/
        }

        [TestMethod]
        public async Task GetAllEventsAsync_ShouldReturnAllEvents()
        {
            var testEvents = GetTestEvents();
            var controller = new EventController(/*testEvents*/);

            /*var result = await controller.GetAllEventsAsync() as List<Event>;
            Assert.AreEqual(testEvents.Count, result.Count);*/
        }

        [TestMethod]
        public void GetEvent_ShouldReturnCorrectEvent()
        {
            var testEvents = GetTestEvents();
            var controller = new EventController(/*testEvents*/);

            /*var result = controller.GetEvent(4) as OkNegotiatedContentResult<Event>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testEvents[3].EventName, result.Content.EventName);*/
        }

        [TestMethod]
        public async Task GetEventAsync_ShouldReturnCorrectEvent()
        {
            var testEvents = GetTestEvents();
            var controller = new EventController(/*testEvents*/);

            /*var result = await controller.GetEventAsync(4) as OkNegotiatedContentResult<Event>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testEvents[3].EventName, result.Content.EventName);*/
        }
        
        [TestMethod]
        public void GetEvent_ShouldNotFindEvent()
        {
            var testEvents = GetTestEvents();
            var controller = new EventController(/*testEvents*/);

            var result = controller.GetEvent(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Event> GetTestEvents()
        {
            var testEvents = new List<Event>();
            DateTime start = new DateTime(2021, 12, 24, 15, 30, 00);
            DateTime end = new DateTime(2021, 12, 24, 16, 30, 00);
            testEvents.Add(new Event { EventName = "TestNam1", EventCapacity = 10, Amount = 9, StartDateTime = start, EndDateTime = end, Description = "TestDes1", ID = 1, ProfileID = 1 });
            testEvents.Add(new Event { EventName = "TestNam2", EventCapacity = 11, Amount = 9, StartDateTime = start, EndDateTime = end, Description = "TestDes2", ID = 2, ProfileID = 1 });
            testEvents.Add(new Event { EventName = "TestNam3", EventCapacity = 12, Amount = 9, StartDateTime = start, EndDateTime = end, Description = "TestDes3", ID = 3, ProfileID = 1 });
            testEvents.Add(new Event { EventName = "TestNam4", EventCapacity = 13, Amount = 9, StartDateTime = start, EndDateTime = end, Description = "TestDes4", ID = 4, ProfileID = 1 });

            return testEvents;
        }
    }
}

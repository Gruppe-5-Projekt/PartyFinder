using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebApi.Controllers;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            EventController eventController = new EventController;
            EventDB eventDB = new EventDB();
            string eventName = "TESTFEST";
            int eventCapacity = 2;
            int amount = 1;
            //int year, int month, int day, int hour, int minute
            DateTime start = new DateTime(2021, 12, 4, 15, 30, 00);
            DateTime end = new DateTime(2021, 12, 24, 15, 30, 00);
            string description = "Fri bar første time";
            int profileID = 1;


            // Act
            //IEnumerable<string> result = controller.Get();
            eventController.createEvent(eventName, eventCapacity, amount, start, end, description, profileID);
            eventController.insertEvent();
            /*List<Event> events = eventController.listEvents();
            Event currEvent = events.get(events.size - 1);
            String currEventName = currEvent.getEventName();
            currEventID = currEvent.getEventID();*/
            // Assert
            //Assert.AreEqual(eventName, currEventName);
            //Assert.AreEqual(eventName, eventDB.findEvent("TESTFEST"));

        }
    }
}

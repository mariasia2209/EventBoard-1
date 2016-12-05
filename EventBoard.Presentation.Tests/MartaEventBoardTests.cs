using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventBoard.Presentation.Tests.DatabaseHelpers;
using TestContext = EventBoard.Presentation.Tests.DatabaseHelpers.TestContext;
using EventBoard.DataAccess.EntityFramework;
using System.Collections.Generic;
using EventBoard.Domain;
using EventBoard.Domain.Models;
using System.Linq;

namespace EventBoard.Presentation.Tests
{
    [TestClass]
    public class MartaEventBoardTests
    {
        [TestMethod]
        public void GetEventsByCategoryTest()
        {
            // Arrange
            TestContext context = new TestContext();

            Category category1, category2, category3, category4;
            context.Categories.AddRange(new[] {
                category1 = new Category { Id = 1, Name = "Sport" },
                category2 = new Category { Id = 22, Name = "Nightlife"},
                category3 = new Category { Id = 31, Name = "Social"},
                category4 = new Category { Id = 44, Name = "Nothing"}});

            User user1, user2;
            context.Users.AddRange(new[] {
                user1 = new User { Id = "qWeRtY", FirstName = "John", SecondName = "Dou"},
                user2 = new User { Id = "bOmB", FirstName = "Billy", SecondName = "Halligan"}
            });

            Event event1, event2, event3, event4, event5, event6;
            context.Events.AddRange(new[] {
                event1 = new Event { Id = 1, Name = "Event 1", User = user1, Creator_Id = user1.Id, Category = category3, Category_Id = category3.Id},
                event2 = new Event { Id = 2, Name = "Event 2", User = user1, Creator_Id = user1.Id, Category = category3, Category_Id = category3.Id},
                event3 = new Event { Id = 3, Name = "Event 3", User = user2, Creator_Id = user2.Id, Category = category3, Category_Id = category3.Id},
                event4 = new Event { Id = 4, Name = "Event 4", User = user2, Creator_Id = user2.Id, Category = category2, Category_Id = category2.Id},
                event5 = new Event { Id = 5, Name = "Event 5", User = user2, Creator_Id = user1.Id, Category = category2, Category_Id = category2.Id},
                event6 = new Event { Id = 6, Name = "Event 6", User = user1, Creator_Id = user2.Id, Category = category1, Category_Id = category1.Id}
            });

            category1.Events = new List<Event> { event6 };
            category2.Events = new List<Event> { event4, event5};
            category3.Events = new List<Event> { event1, event2, event3};
            category4.Events = new List<Event>();

            // Act
            EventService eventService = new EventService(context);
            CategoryEventsViewModel
                eventsCategory1 = eventService.GetEventsByCategory(category1.Id),
                eventsCategory2 = eventService.GetEventsByCategory(category2.Id),
                eventsCategory3 = eventService.GetEventsByCategory(category3.Id),
                eventsCategory4 = eventService.GetEventsByCategory(category4.Id),
                eventsCategoryNone = eventService.GetEventsByCategory(100);

            List<int> category3Events = eventsCategory3.Events.Select(e => e.Id).ToList();
            List<int> category2Events = eventsCategory2.Events.Select(e => e.Id).ToList();
            List<int> category1Events = eventsCategory1.Events.Select(e => e.Id).ToList();

            // Assert
            Assert.AreEqual(eventsCategory1.Events.First().Name, "Event 6");
            Assert.AreEqual(eventsCategory1.Events.Count, 1);
            Assert.AreEqual(eventsCategory2.Events.Count, 2);
            Assert.AreEqual(eventsCategory3.Events.Count, 3);
            Assert.AreEqual(eventsCategory4.Events.Count, 0);
            Assert.IsNull(eventsCategoryNone);
            Assert.IsTrue(category3Events.Contains(1) && category3Events.Contains(2) && category3Events.Contains(3));
            Assert.IsTrue(category2Events.Contains(4) && category2Events.Contains(5));
            Assert.IsTrue(category1Events.Contains(6));
        }
    }
}

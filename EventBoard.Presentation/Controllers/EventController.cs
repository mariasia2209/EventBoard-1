using EventBoard.Domain;
using EventBoard.Domain.Models;
using System;
using System.Web.Mvc;

namespace EventBoard.Presentation.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService EventService;

        public EventController(IEventService eventService)
        {
            EventService = eventService;
        }

        // GET: Event
        public ActionResult Index(int? eventId)
        {
            if (eventId == null)
            {
                AllEventsModel allEvents = EventService.GetAllEvents();

                return View(allEvents);
            }
            else
            {
                EventFullModel eventFullModel = EventService.GetEvent(eventId.Value);

                return View("Event", eventFullModel);
            }
        }

        public ActionResult Tag(int? tagId)
        {
            return View(tagId);
        }

        public ActionResult Category(int? categoryId)
        {
            return View(categoryId);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            EventNewViewModel newEvent = new EventNewViewModel {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            return View(newEvent);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(EventNewViewModel newEvent)
        {
            string userName = User.Identity.Name;

            int eventId = EventService.CreateNewEvent(newEvent, userName);

            return RedirectToAction("Index", "Event", new { eventId = eventId });
        }
    }
}
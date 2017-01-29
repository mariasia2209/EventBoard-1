using EventBoard.Domain;
using EventBoard.Domain.Models;
using System;
using System.Collections.Generic;
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
                string userName = null;
                if (User != null)
                {
                    userName = User.Identity.Name;
                }
                
                EventFullModel eventFullModel = EventService.GetEvent(eventId.Value, userName);

                return View("Event", eventFullModel);
            }
        }

        public ActionResult Tag(int? tagId)
        {

            return View(tagId);
        }

        public ActionResult Category(int? categoryId)
        {
            CategoryEventsViewModel events = EventService.GetEventsByCategory(categoryId ?? 0);

            return View(events);
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
        static int ID;
        [Authorize]
        [HttpGet]
        public ActionResult EditEvent(int eventId)
        {
            ID = eventId;
            EventFullModel editEvent = EventService.GetEvent(eventId, User.Identity.Name);
            EventNewViewModel newEvent = new EventNewViewModel();
            newEvent.Name = editEvent.Name;
            newEvent.Description = editEvent.Description;
            newEvent.Category = editEvent.CategoryName;
            newEvent.StartTime = Convert.ToDateTime(editEvent.StartDate);
            newEvent.EndTime = Convert.ToDateTime(editEvent.EndDate);
            newEvent.Location = "";
            newEvent.Suspended = editEvent.Suspended;
            return View(newEvent);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditEvent(EventNewViewModel newEvent)
        {
            string userName = User.Identity.Name;

            int eventId = EventService.UpdateEvent(newEvent, userName, ID);

            return RedirectToAction("Index", "Event", new { eventId = eventId });
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddComment(CommentNewViewModel comment, int eventId)
        {
            string userName = User.Identity.Name;

            comment.EventId = eventId;

            EventService.AddNewComment(userName, comment);

            return RedirectToAction("Index", "Event", new { eventId = eventId });
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddComment(int eventId)
        {
            CommentNewViewModel newComment = new CommentNewViewModel
            {
                EventId = eventId
            };

            return View(newComment);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Like(int eventId)
        {
            string userName = User.Identity.Name;

            EventService.AddLike(eventId, userName);

            return RedirectToAction("Index", "Event", new { eventId = eventId });
        }
    }
}
using EventBoard.Domain;
using EventBoard.Domain.Models;
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
        public ActionResult Index()
        {
            AllEventsModel allEvents = EventService.GetAllEvents();

            return View(allEvents);
        }

        public ActionResult Tag(int tagId)
        {
            return View(tagId);
        }

        public ActionResult Category(int categoryId)
        {
            return View(categoryId);
        }
    }
}
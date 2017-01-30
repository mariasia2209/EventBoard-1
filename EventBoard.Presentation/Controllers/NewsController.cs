using EventBoard.Domain;
using EventBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EventBoard.Presentation.Controllers
{
    public class NewsController : Controller
    {
        private readonly IEventService EventService;

        public NewsController(IEventService eventService)
        {
            EventService = eventService;
        }

        // GET: Event
        public ActionResult Index(int? eventId)
        {
            string userName = User.Identity.Name;
            
            List<FullNews> allNews = EventService.GetNewsForUser(userName);

            return View(allNews);        
        }

    }
}
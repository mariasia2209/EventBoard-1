using System.Collections.Generic;

namespace EventBoard.Domain.Models
{
    public class CategoryEventsViewModel
    {
        public List<EventHeaderModel> Events { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

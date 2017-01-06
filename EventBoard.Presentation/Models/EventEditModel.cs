using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventBoard.Presentation.Models
{

        public class EventEditModel
        {
            public int Id { get; set; }
            public DateTime CreationTime { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public string Description { get; set; }
            public bool IsLikedByCurrentUser { get; set; }
            public bool Suspended { get; set; }
    }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.Domain.Models
{
    public class AllEventsModel
    {
        public List<EventShortModel> Events { get; set; }
        public EventsSummaryModel Statistics { get; set; }
        public List<TagModel> Tags { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }
}

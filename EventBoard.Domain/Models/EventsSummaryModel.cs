using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.Domain.Models
{
    public class EventsSummaryModel
    {
        public int TotalEventCount { get; set; } 
        public int TotalTagCount { get; set; }
        public int TotalCategoryCount { get; set; }
        public int TotalNewsCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.Domain.Models
{
    public class EventCommentsSummaryModel
    {
        public int Count { get; set; }
        public DateTime? LastCommentDate { get; set; }
    }
}

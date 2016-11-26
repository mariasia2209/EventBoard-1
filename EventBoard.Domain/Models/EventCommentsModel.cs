using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.Domain.Models
{
    public class EventCommentModel
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }
        public UserShortModel User { get; set; }
    }
}

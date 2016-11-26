using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.Domain.Models
{
    public class EventLikeCounterModel
    {
        public int Count { get; set; }
        public List<UserShortModel> Users { get; set; }
    }
}

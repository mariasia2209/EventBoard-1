using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.Domain.Models
{
    public class EventShortModel
    {
        public int Id { get; set; }
        public CreatorModel Creator { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public EventLikeCounterModel Likes { get; set; }
        public List<TagModel> Tags { get; set; }
        public EventCommentsSummaryModel Comments { get; set; }
    }
}

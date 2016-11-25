using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.Domain.Models
{
    public class StrictEventModel
    {
        public CreatorModel Creator { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EventLikeCounterModel Likes { get; set; }
        public List<TagModel> Tags { get; set; }
        public int CommentsCount { get; set; }
        public EventCommentsSummaryModel Comments { get; set; }
    }
}

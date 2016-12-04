using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.Domain.Models
{
    public class EventFullModel
    {
        public int Id { get; set; }
        public CreatorModel Creator { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public EventLikeCounterModel Likes { get; set; }
        public List<TagModel> Tags { get; set; }
        public List<EventCommentModel> Comments { get; set; }
        public bool IsLikedByCurrentUser { get; set; }
    }
}

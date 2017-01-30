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
        public string Image { get; set; }
        public string Description { get; set; }
        public EventLikeCounterModel Likes { get; set; }
        public List<TagModel> Tags { get; set; }
        public EventCommentsSummaryModel Comments { get; set; }
        public bool Suspended { get; set; }
        public string Status
        {
            get
            {
                return Suspended ? "Inactive" : "Active";
            }
        }
        public string ShortDescription
        {
            get
            {
                int expectedSize = 120;
                return Description == null ? "" : Description.Length > expectedSize ? Description.Substring(0, Description.Substring(0, expectedSize - 3).LastIndexOf(' ')) + "...": Description;
            }
        }
        public string Creator_Id { get; set; }
    }
}

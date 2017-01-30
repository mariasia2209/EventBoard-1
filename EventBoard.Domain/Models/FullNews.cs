using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.Domain.Models
{
    public class FullNews
    {
        public int Id { get; set; }

        public string Heading { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime Time { get; set; }

        public EventHeaderModel Event { get; set; }

        public CreatorModel User { get; set; }
    }
}

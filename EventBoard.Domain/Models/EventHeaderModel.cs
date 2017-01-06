using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.Domain.Models
{
    public class EventHeaderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public bool Suspended { get; set; }
    }
}

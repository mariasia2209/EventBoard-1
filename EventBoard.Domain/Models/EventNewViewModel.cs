using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.Domain.Models
{
    public class EventNewViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        public string Description { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Start of event")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY-MM-DD hh:mm}")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End of event")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY-MM-DD hh:mm}")]
        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Deactivate")]
        public bool Suspended { get; set; }
    }  
}

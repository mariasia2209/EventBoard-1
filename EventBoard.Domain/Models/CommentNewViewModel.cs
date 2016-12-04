using System;
using System.ComponentModel.DataAnnotations;

namespace EventBoard.Domain.Models
{
    public class CommentNewViewModel
    {
        [Required]
        [Display(Name = "Comment")]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Text { get; set; }

        public int? EventId { get; set; }
    }
}

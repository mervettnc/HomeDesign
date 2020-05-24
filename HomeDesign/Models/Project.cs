using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeDesign.Models
{
    public class Project
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        public string PhotoPath { get; set; }

        [Required]
        [MaxLength(100)]
        public string Slug { get; set; }

        [Required]
        public DateTime? CreationTime { get; set; }

        [Required]
        public DateTime? ModificationTime { get; set; }
        public virtual  ApplicationUser User { get; set; }
        public virtual Category Category { get; set; }
    }
}
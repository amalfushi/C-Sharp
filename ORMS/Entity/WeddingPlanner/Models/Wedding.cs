using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding: BaseEntity
    {
        [Key]
        public int WeddingId { get; set; }
        public string Wedder1 { get; set; }
        public string Wedder2 { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public List<RSVP> Attendees { get; set; }
    }

    public class CreWedding : BaseEntity
    {
        [Required]
        [Display(Name = "Wedder One")]
        public string Wedder1 { get; set; }

        [Required]
        [Display(Name = "Wedder One")]
        public string Wedder2 { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        // [DataType(DataType.MultilineText)]
        // [DataType(DataType.PostalCode)]
        public string Address { get; set; }
    }
}
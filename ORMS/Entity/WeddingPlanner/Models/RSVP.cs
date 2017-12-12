using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class RSVP: BaseEntity
    {
        [Key]
        public int RSVPId { get; set;}
        public int UserId { get; set; }
        public User User { get; set;}
        public int WeddingId { get; set; }
        public Wedding Wedding { get; set; }

        // public List<User> Guests { get; set; }
    }
}
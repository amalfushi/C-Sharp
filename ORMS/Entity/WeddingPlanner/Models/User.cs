using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class User: BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // public Wedding Created { get; set; }
        
        // public List<RSVP> RSVPs { get; set;}
        // public float Balance { get; set; }
        // public List<Transaction> Transactions { get; set;}

        // public User()
        // {
        //     Attending = new List<WeddingAttendance>();
        // }
    }
}
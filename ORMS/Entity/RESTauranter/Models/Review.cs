using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class Review : BaseEntity
    {
        [Required]
        
        public int ReviewId { get; set; }

        [Required]
        [Display(Name = "Reviewer Name: ")]
        public string ReviewerName { get; set; }

        [Required]
        [Display(Name = "Restaurant Name: ")]
        public string RestaurantName { get; set; }

        [Required]
        [Display(Name = "Review: ")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Date Visited: ")]
        public DateTime DateVisited { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
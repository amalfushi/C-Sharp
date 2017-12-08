using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models
{
    public class NewTrail : BaseEntity
    {
        [Required(ErrorMessage = "Trail name is required.")]
        [MinLength(4, ErrorMessage="Trail names must be at least 4 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(10, ErrorMessage="Description must be at least 10 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Trail length is required.")]
        [Range(0,5000, ErrorMessage="Invalid trail length.")]
        public float Length { get; set; }

        [Required(ErrorMessage = "Elevation change is required.")]
        [Display(Name = "Elevation Change")]
        public int ElevationChange { get; set; }

        [Required(ErrorMessage = "Longitude value is required.")]
        [Range(-180, 180, ErrorMessage = "Invalid longitude.")]
        public float Longitude { get; set; }
        
        [Required(ErrorMessage = "Latitude value is required.")]
        [Range(-90, 90, ErrorMessage = "Invalid Latitude.")]
        public float Latitude { get; set; }
    }
}
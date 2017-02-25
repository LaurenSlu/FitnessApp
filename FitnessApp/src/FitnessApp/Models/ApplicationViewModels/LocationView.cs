using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class LocationView
    {
        [Required(ErrorMessage = "Please choose a Location")]
        public int Id { get; set; }

        [Display(Name = "Location")]
        public string Name { get; set; }
    }
}

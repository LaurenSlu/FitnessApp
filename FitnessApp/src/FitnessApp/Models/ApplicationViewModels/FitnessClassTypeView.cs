using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassTypeView
    {
        [Required(ErrorMessage = "Please choose a Fitness Class")]
        public int Id { get; set; }

        [Display(Name = "Fitness Class")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; }

    }
}

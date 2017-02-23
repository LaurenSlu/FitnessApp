using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class InstructorView
    {
        [Required(ErrorMessage = "Please choose an Instructor")]
        public int Id { get; set; }

        [Display(Name = "Instructor")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; }

    }
}

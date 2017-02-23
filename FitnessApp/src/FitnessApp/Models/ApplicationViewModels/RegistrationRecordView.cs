using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class RegistrationRecordView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }

        [Display(Name = "On Wait List")]
        public bool WaitListed { get; set; }

        public int FitnessClass_Id { get; set; }

        [Display(Name = "Fitness Classes")]
        public FitnessClassView FitnessClass { get; set; }
    }
}

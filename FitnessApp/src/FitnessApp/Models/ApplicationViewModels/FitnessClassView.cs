using ApplicationModels.FitnessApp.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassView
    {
        public int Id { get; set; }

        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        [Display(Name = "Class Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfClass { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; }

        [Display(Name = "Capacity")]
        public int Capacity { get; set; }

        [Display(Name = "Type of Class")]
        public FitnessClassType FitnessClassType { get; set; }

        [Display(Name = "Instructor")]
        public Instructor Instructor { get; set; }

        [Display(Name = "Room")]
        public Location Location { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassView
    {
        public int Id { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = " Please pick a start time")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = @"{0:h\:mm}")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "End Time")]
        [Required(ErrorMessage = " Please pick an end time")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = @"{0:h\:mm}")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Class Date")]
        [Required(ErrorMessage = " Please pick a date for the class")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfClass { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; }

        [Display(Name = "Capacity")]
        [Required(ErrorMessage = "Please choose a Capacity between 1 and 100")]
        [Range(1, 100, ErrorMessage = "Please choose a Capacity between 1 and 100")]
        public int Capacity { get; set; }

        [Display(Name = "Fitness Class")]
        public FitnessClassTypeView FitnessClassType { get; set; }

        public ICollection<SelectListItem> FitnessClassTypes { get; set; }

        [Display(Name = "Instructor")]
        public InstructorView Instructor { get; set; }

        public ICollection<SelectListItem> Instructors { get; set; }

        [Display(Name = "Room")]
        public LocationView Location { get; set; }

        public ICollection<SelectListItem> Locations { get; set; }
    }
}

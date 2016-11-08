using FitnessApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationModels.FitnessApp.Models
{
    public class FitnessClass : EntityBase
    {
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

        public int FitnessClassType_Id { get; set; }
        public FitnessClassType FitnessClassType { get; set; }

        public int Instructors_Id { get; set; }
        public Instructor Instructor { get; set; }

        public int Location_Id { get; set; }
        public Location Location { get; set; }

        public List<RegistrationRecord> RegistrationRecords { get; set; }
    }
}

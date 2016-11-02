﻿using System;
using System.ComponentModel;

namespace ApplicationModels.FitnessApp.Models
{
    public class FitnessClassListItem
    {
        public int Id { get; set; }

        [DisplayName("Start Time")]
        public string StartTime { get; set; }

        [DisplayName("End Time")]
        public string EndTime { get; set; }

        [DisplayName("Class Date")]
        public DateTime DateOfClass { get; set; }

        public bool Status { get; set; }

        [DisplayName("Capacity")]
        public int Capacity { get; set; }

        [DisplayName("Class")]
        public string ClassType { get; set; }

        [DisplayName("Instructor")]
        public string Instructor { get; set; }

        [DisplayName("Location")]
        public string Location { get; set; }
    }
}

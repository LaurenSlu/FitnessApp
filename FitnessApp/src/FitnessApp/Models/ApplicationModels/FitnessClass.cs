using FitnessApp.Core;
using System;
using System.Collections.Generic;

namespace ApplicationModels.FitnessApp.Models
{
    public class FitnessClass : EntityBase
    {
        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public DateTime DateOfClass { get; set; }

        public bool Status { get; set; }

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

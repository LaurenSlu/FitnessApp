﻿using FitnessApp.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace FitnessApp.Models
{
    public class FitnessClass : EntityBase
    {
        private ICollection<RegistrationRecord> _registrationRecords;

        [DataMember]
        [Required]
        public string StartTime { get; set; }

        [DataMember]
        [Required]
        public string EndTime { get; set; }

        [DataMember]
        [Required]
        public DateTime DateOfClass { get; set; }

        [DataMember]
        public bool Status { get; set; }

        [DataMember]
        public int Capacity { get; set; }

        [ForeignKey("FitnessClassType_Id")]
        public virtual FitnessClassType FitnessClassType { get; set; }

        [ForeignKey("Instructors_Id")]
        public virtual Instructor Instructor { get; set; }

        [ForeignKey("Locations_Id")]
        public virtual Location Location { get; set; }

        public virtual ICollection<RegistrationRecord> RegistrationRecords
        {
            get { return _registrationRecords ?? (new Collection<RegistrationRecord>()); }
            set { _registrationRecords = value; }
        }
    }
}

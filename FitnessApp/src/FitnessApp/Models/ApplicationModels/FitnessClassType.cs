﻿using FitnessApp.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ApplicationModels.FitnessApp.Models
{
    public class FitnessClassType : EntityBase
    {
        private ICollection<FitnessClass> _fitnessClass;

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        public bool Status { get; set; }

        public virtual ICollection<FitnessClass> FitnessClass
        {
            get { return _fitnessClass ?? (new Collection<FitnessClass>()); }
            set { _fitnessClass = value; }
        }
    }
}

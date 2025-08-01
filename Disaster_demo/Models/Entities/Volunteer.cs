﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disaster_demo.Models.Entities
{


    public class Volunteer : Users
    {

       
        public string name { get; set; }

        public string district { get; set; }

        public string divisional_secretariat { get; set; }

        public AvailabilityStatus availability { get; set; } = AvailabilityStatus.Unavailable;
        public string contact_number { get; set; }
    }
}
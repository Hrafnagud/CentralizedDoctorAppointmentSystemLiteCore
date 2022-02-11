﻿using CDASLiteEntityLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Models
{
    public class HospitalClinics : Base<int>
    {
        //Hospital
        public int HospitalId { get; set; }
        [ForeignKey("HospitalId")]

        public virtual Hospital Hospital { get; set; }

        public int ClinicId { get; set; }   //Relationship with clinic
        [ForeignKey("ClinicId")]
        public virtual Clinic Clinic { get; set; }

        public string DoctorId { get; set; }    //Relationship with doctor
        [ForeignKey("DoctorId")]

        public virtual Doctor Doctor { get; set; }

    }
}
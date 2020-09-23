using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalWard.Models
{
    public class Ward
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        [Required]
        public int NurseID { get; set; }
        public Nurse Nurse { get; set; }
        [Required]
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        public List<Patient> Patients { get; set; }
    }
}
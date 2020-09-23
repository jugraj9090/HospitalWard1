using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalWard.Models
{
    public class Doctor
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string Specialty { get; set; }
        public List<Ward> Wards { get; set; }
    }
}
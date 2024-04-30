﻿using Dapper.Contrib.Extensions;
using Prescription.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace Prescription.DAL.Entities
{
    [Table("Prescript")]
    public class Prescript: ISoftDeleted
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public long PatientId { get; set; }
        [Computed]
        public Patient? Patient { get; set; }
        public long DoctorId { get; set; }
        [Computed]
        public Doctor? Doctor { get; set; }
        public long InsuranceId { get; set; }
        [Computed]
        public Insurance? Insurance { get; set; }
        public bool Deleted { get; set; }
        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public long DocumentId { get; set; }
        [Computed]
        public Document? Document { get; set; }
        [Computed]
        public List<Service> Services { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECC.Data
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Bed Bed { get; set; }
        public Patient Patient { get; set; }
        public string Body { get; set; }
        [StringLength(100)]
        public string Staff { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsAdmission { get; set; }
    }
}
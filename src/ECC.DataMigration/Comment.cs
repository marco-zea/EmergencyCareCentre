using System;
namespace ECC.DataMigration
{ 
    public class Comment
    {
        public int Id { get; set; }
        public Bed Bed { get; set; }
        public Patient Patient { get; set; }
        public string Body { get; set; }
        public string Staff { get; set; }
        public DateTime LastUpated { get; set; }
    }
}
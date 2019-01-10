using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace owl.api.Models
{
    public partial class Incidents
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Managers { get; set; }
        public long? Impacted { get; set; }
        public long? Casualties { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

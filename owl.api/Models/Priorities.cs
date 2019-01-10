using System;
using System.Collections.Generic;

namespace owl.api.Models
{
    public partial class Priorities
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Details { get; set; }
        public long? IncidentId { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}

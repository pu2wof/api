using System;
using System.Collections.Generic;

namespace owl.api.Models
{
    public partial class Resources
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}

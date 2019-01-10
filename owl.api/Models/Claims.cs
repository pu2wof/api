using System;
using System.Collections.Generic;

namespace owl.api.Models
{
    public partial class Claims
    {
        public long Id { get; set; }
        public string File { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}

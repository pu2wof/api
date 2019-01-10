using System;
using System.Collections.Generic;

namespace owl.api.Models
{
    public partial class Notifications
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}

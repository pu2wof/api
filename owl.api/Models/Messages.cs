using System;
using System.Collections.Generic;

namespace owl.api.Models
{
    public partial class Messages
    {
        public long Id { get; set; }
        public long? Sender { get; set; }
        public long? Recipient { get; set; }
        public string Message { get; set; }
        public string File { get; set; }
        public string Read { get; set; }
        public string Mtype { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}

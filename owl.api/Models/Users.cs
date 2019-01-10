using System;
using System.Collections.Generic;

namespace owl.api.Models
{
    public partial class Users
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string RememberToken { get; set; }
        public string PasswordDigest { get; set; }
        public long? Incident { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdControl.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime EmailVerified { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string PhoneNo { get; set; }
        public string Description { get; set; }
        public string ProffileImage { get; set; }
        public Boolean HasBusiness { get; set; }

    }
}

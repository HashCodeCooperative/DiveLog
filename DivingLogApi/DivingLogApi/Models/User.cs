using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivingLogApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public bool IsRegistered { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string About { get; set; }
        public List<UserDive> UserDives { get; set; }
    }
}

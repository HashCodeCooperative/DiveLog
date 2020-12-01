using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivingLogApi.Dtos
{
    public class UserForAuthorizationDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}

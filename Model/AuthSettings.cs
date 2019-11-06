using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.API.Model
{
    public class AuthSettings : IAuthSettings
    {
        public string Username { get; set; }
        public string Password { get;  set; }
    }

    public interface IAuthSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

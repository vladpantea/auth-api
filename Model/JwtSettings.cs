using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.API.Model
{
    public class JwtSettings : IJwtSettings
    {
        public string Secret { get; set; }

        public string Audience { get; set; }

        public string Issuer { get; set; }

    }

    public interface IJwtSettings
    {
        public string Secret { get; set; }

        public string Audience { get; set; }

        public string Issuer { get; set; }
    }
}

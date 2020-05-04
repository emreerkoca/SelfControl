using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Infrastructure.Helper
{
    public class AuthenticationData
    {
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
}

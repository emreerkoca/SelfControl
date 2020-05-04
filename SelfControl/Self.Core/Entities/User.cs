using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
    }
}

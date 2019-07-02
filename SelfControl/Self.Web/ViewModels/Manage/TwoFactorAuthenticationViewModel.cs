using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Self.Web.ViewModels.Manage
{
    public class TwoFactorAuthenticationViewModel
    {
        public bool HasAuthenticator { get; set; }
        public int RecoveryCodesLeft { get; set; }
        public bool Is2faEnabled { get; set; }
    }
}

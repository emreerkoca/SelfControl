using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Core.SharedKernel
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)] 
    public class IgnoreMemberAttribute : Attribute 
    {

    }
}

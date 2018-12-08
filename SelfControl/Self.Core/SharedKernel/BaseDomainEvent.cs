using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Core.SharedKernel
{
    public abstract class BaseDomainEvent
    {
        public DateTime DateOccured { get; protected set; } = DateTime.UtcNow;
    }
}

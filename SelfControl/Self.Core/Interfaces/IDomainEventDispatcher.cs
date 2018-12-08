using Self.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}

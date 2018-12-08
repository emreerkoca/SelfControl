using Self.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}

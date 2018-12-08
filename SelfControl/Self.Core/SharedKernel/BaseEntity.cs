using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Core.SharedKernel
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}

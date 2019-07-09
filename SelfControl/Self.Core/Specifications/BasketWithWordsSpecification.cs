using Self.Core.Entities.BasketAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Core.Specifications
{
    public sealed class BasketWithWordsSpecification : BaseSpecification<Basket>
    {
        public BasketWithWordsSpecification(int basketId)
            : base(b => b.Id == basketId)
        {
            AddInclude(b => b.Words);
        }
        public BasketWithWordsSpecification(string ownerId)
            : base(b => b.OwnerId == ownerId)
        {
            AddInclude(b => b.Words);
        }
    }
}

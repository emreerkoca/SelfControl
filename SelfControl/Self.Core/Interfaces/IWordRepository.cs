using Self.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Core.Interfaces
{
    public interface IWordRepository : IRepository<Word>, IAsyncRepository<Word>
    {

    }
}

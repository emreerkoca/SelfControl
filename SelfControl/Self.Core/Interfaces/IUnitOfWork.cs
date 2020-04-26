using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Self.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IWordRepository Words { get; }
        Task<int> CommitAsync();
    }
}

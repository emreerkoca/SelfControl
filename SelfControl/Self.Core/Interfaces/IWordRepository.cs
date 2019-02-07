﻿using Self.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Self.Core.Interfaces
{
    public interface IWordRepository : IRepository<Word>, IAsyncRepository<Word>
    {
        Word GetRandomWord();
        Task<Word> GetRandomWordAsync();
    }
}
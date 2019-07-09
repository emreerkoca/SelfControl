using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Self.Core.Entities.BasketAggregate
{
    public class Basket : BaseEntity
    {
        public string OwnerId { get; set; }
        public readonly List<Word> _words = new List<Word>();
        public IReadOnlyCollection<Word> Words => _words.AsReadOnly();


        public void AddItem(int wordId)
        {
            if(!Words.Any(i => i.Id == wordId))
            {
                _words.Add(new Word()
                {
                    Id = wordId
                });
            }

           
        }
    }
}

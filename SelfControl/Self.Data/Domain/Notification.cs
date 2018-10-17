using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.Data.Domain
{
    public class Notification : BaseEntity
    {
        public string OriginalWord { get; set; }

        public string TranslatedWord { get; set; }

        public string Sentence { get; set; }
    }
}

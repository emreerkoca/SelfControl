using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Self.Web.ViewModels.Basket
{
    public class WordViewModel
    {
        public int Id { get; set; }
        public string OriginalWord { get; set; }
        public string TranslatedWord { get; set; }
        public int ViewCount { get; set; }
        public string Sentence { get; set; }
    }
}

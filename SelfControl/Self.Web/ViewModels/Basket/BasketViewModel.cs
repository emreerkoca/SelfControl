using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Self.Web.ViewModels.Basket
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public List<WordViewModel> Words { get; set; } = new List<WordViewModel>();
        public string BasketOwnerId { get; set; }
    }
}

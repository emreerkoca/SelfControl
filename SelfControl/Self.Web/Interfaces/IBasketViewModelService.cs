using Self.Web.ViewModels.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Self.Web.Services
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetOrCreateBasketForUserAsync(string userName);
    }
}

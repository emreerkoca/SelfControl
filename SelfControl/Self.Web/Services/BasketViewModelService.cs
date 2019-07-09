using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Self.Core.Entities;
using Self.Core.Entities.BasketAggregate;
using Self.Core.Interfaces;
using Self.Core.Specifications;
using Self.Web.ViewModels.Basket;

namespace Self.Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IAsyncRepository<Word> _wordRepository;

        public BasketViewModelService(IAsyncRepository<Basket> basketRepository,
            IAsyncRepository<Word> wordRepository)
        {
            _basketRepository = basketRepository;
            _wordRepository = wordRepository;
        }

        public async Task<BasketViewModel> GetOrCreateBasketForUserAsync(string userName)
        {
            var basketSpecification = new BasketWithWordsSpecification(userName);
            var basket = (await _basketRepository.GetListAsync(basketSpecification)).FirstOrDefault();

            if (basket == null)
            {
                return await CreateBasketForUser(userName);
            }

            return await CreateViewModelFromBasket(basket);
        }

        private async Task<BasketViewModel> CreateViewModelFromBasket(Basket basket)
        {
            var viewModel = new BasketViewModel();
            viewModel.Id = basket.Id;
            viewModel.BasketOwnerId = basket.OwnerId;
            viewModel.Words = await GetBasketItems(basket.Words); ;
            return viewModel;
        }

        private async Task<BasketViewModel> CreateBasketForUser(string userId)
        {
            var basket = new Basket() { OwnerId = userId };
            await _basketRepository.AddAsync(basket);

            return new BasketViewModel()
            {
                BasketOwnerId = basket.OwnerId,
                Id = basket.Id,
                Words = new List<WordViewModel>()
            };
        }

        private async Task<List<WordViewModel>> GetBasketItems(IReadOnlyCollection<Word> basketItems)
        {
            var items = new List<WordViewModel>();
            foreach (var item in basketItems)
            {
                var itemModel = new WordViewModel
                {
                    Id = item.Id,
                    OriginalWord = item.OriginalWord,
                    TranslatedWord = item.TranslatedWord,
                    Sentence = item.Sentence,
                    ViewCount = item.ViewCount
                };

                items.Add(itemModel);
            }

            return items;
        }
    }


}

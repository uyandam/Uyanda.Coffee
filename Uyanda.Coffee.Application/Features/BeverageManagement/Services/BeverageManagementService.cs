﻿using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Persistence;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results;
using System.Linq;
using System.Collections.Generic;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Services
{
    public class BeverageManagementService : IBeverageManagementService
    {
        private readonly IBeverageAccessor beverageAccessor;

        public BeverageManagementService(IBeverageAccessor beverageAccessor)
        {
            this.beverageAccessor = beverageAccessor;
        }

        public async Task<AddBeveragesResult> AddBeveragesAsync(AddBeveragesCommand command)
        {
            var result = await beverageAccessor.AddBeveragesAsync(command.Beverages);

            return new AddBeveragesResult { Beverages = result };
        }

        public async Task<GetBeveragesResult> GetBeveragesAsync(GetBeveragesQuery query)
        {

            var queryResult = await beverageAccessor.GetBeveragesAsync(query.Beverages);

            return new GetBeveragesResult { Beverages = queryResult };
        }


        public async Task<AvailableCoffeeCupResult> AvailableCoffeeCupsAsync()
        {
            var result = await beverageAccessor.GetCoffeeCupsAsync();

            return new AvailableCoffeeCupResult { AvailableCoffeeCups = result};
        }

        public async Task<AddBeverageCostResult> AddBeverageCostAsync(AddBeverageCostCommand command)
        {
            var result = await beverageAccessor.AddBeverageCostAsync(command.Prices);

            return new AddBeverageCostResult { Prices = result };

        }

    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;
using Uyanda.Coffee.Application.Features.BeverageManagement.Persistence;
using Uyanda.Coffee.Persistence.Entities;
using System;
using Uyanda.Coffee.Application.Features.BeverageManagement.Requests.Results;


namespace Uyanda.Coffee.Persistence.Accessors
{
    class BeverageAccessor : IBeverageAccessor
    {
        private readonly LocalDbContext localDbContext;
        private readonly IMapper mapper;

        public BeverageAccessor(IUnitOfWork unitOfWork, IMapper mapper)
        {
            localDbContext = (LocalDbContext)unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BeverageModel>> AddBeveragesAsync(IEnumerable<BeverageModel> beverages)
        {
            var entities = beverages.Select(ToEntity);

            localDbContext.Beverages.AddRange(entities);

            await localDbContext.SaveChangesAsync();

            return entities.Select(ToModel);
        }

        public async Task<IEnumerable<BeverageModel>> GetBeveragesAsync(IEnumerable<BeverageModel> beverages)
        {

            var requestedBeverage = beverages.First().Id;
            var dbQuery = from b in localDbContext.Beverages.AsNoTracking()
                          where b.Id == requestedBeverage
                          select b;

            var entities = await dbQuery.ToArrayAsync();

            return entities.Select(ToModel);
        }


        public async Task<IEnumerable<AvailableCoffeeCupModel>> GetCoffeeCupsAsync()
        {
           
            var query = await localDbContext.Beverages.AsNoTracking()
              .GroupBy(l => l.Name)
              .Select(g => new
              AvailableCoffeeCupModel
              {
                  Name = g.Key,
                  Cups = g.Count()
              }).ToListAsync();

            return query;
        }

        public async Task<IEnumerable<BeverageSizeCostModel>> AddBeverageCostAsync(IEnumerable<BeverageSizeCostModel> prices)
        {
            var entities = prices.Select(ToEntity);
            localDbContext.BeverageCost.AddRange(entities);

            await localDbContext.SaveChangesAsync();

            return entities.Select(ToModel);
        }


        public async Task<IEnumerable<BeverageSizeCostModel>> GetBeverageCostAsync()
        {
            var query = await localDbContext.BeverageCost.AsNoTracking()
                        .Include(row => row.Beverage)
                        .ToArrayAsync();

            return query.Select(ToModel);
        }

        public async Task<IEnumerable<LineItemModel>> PurchaseAsync(IEnumerable<LineItemModel> lineItems)
        {
            var costPerItem = await localDbContext.BeverageCost.AsNoTracking()
                .Select(c => new { Id = c.Id, Cost = c.Cost }).ToDictionaryAsync(item => item.Id, item => item.Cost);


            var purchase = lineItems
                .Select(c => new LineItemEntity { 
                    BeverageSizeCostId = c.BeverageSizeCostId,
                    Count = c.Count,
                    CostPerItem = costPerItem[c.BeverageSizeCostId]
                });
            
            var invoice = new InvoiceEntity { Date = DateTime.Now, LineItems = purchase.ToArray()};

            localDbContext.Invoice.Add(invoice);

            await localDbContext.SaveChangesAsync();
           
            return purchase.Select(ToModel);
        }


        private BeverageModel ToModel(BeverageEntity entity) => mapper.Map<BeverageModel>(entity);

        private BeverageEntity ToEntity(BeverageModel model) => mapper.Map<BeverageEntity>(model);

        //-----------------------------------------------------------------------------------------
        private BeverageSizeCostModel ToModel(BeverageSizeCostEntity entity) => mapper.Map<BeverageSizeCostModel>(entity);

        private BeverageSizeCostEntity ToEntity(BeverageSizeCostModel model) => mapper.Map<BeverageSizeCostEntity>(model);

        //-----------------------------------------------------------------------------------------
        private LineItemModel ToModel(LineItemEntity entity) => mapper.Map<LineItemModel>(entity);

        private LineItemEntity ToEntity(LineItemModel model) => mapper.Map<LineItemEntity>(model);
        //-----------------------------------------------------------------------------------------
        private InvoiceModel ToModel(InvoiceEntity entity) => mapper.Map<InvoiceModel>(entity);

        private InvoiceEntity ToEntity(InvoiceModel model) => mapper.Map<InvoiceEntity>(model);

        //-----------------------------------------------------------------------------------------
        private BeverageSizeModel ToModel(BeverageSizeEntity entity) => mapper.Map<BeverageSizeModel>(entity);

        private BeverageSizeEntity ToEntity(BeverageSizeModel model) => mapper.Map<BeverageSizeEntity>(model);
        //-----------------------------------------------------------------------------------------
        private BeverageTypeModel ToModel(BeverageTypeEntity entity) => mapper.Map<BeverageTypeModel>(entity);

        private BeverageTypeEntity ToEntity(BeverageTypeModel model) => mapper.Map<BeverageTypeEntity>(model);

        //-----------------------------------------------------------------------------------------

    }
}

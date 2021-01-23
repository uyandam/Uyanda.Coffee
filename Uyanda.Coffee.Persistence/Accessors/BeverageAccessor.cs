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

     

        public async Task<BeverageSizeCostModel[]> AddBeverageCostAsync(IEnumerable<BeverageSizeCostModel> prices)
        {
            var entities = prices.Select(ToEntity).ToArray();
            localDbContext.BeverageCost.AddRange(entities);

            await localDbContext.SaveChangesAsync();

            return entities.Select(ToModel).ToArray();
        }


        public async Task<BeverageSizeCostModel[]> GetBeverageCostAsync()
        {
            var query = await localDbContext.BeverageCost.AsNoTracking()
                        .Include(row => row.Beverage)
                        .ToArrayAsync();

            return query.Select(ToModel).ToArray();
        }

        public async Task<InvoiceModel> PurchaseAsync(IEnumerable<LineItemModel> lineItems)
        {
            var costPerItem = await localDbContext.BeverageCost.AsNoTracking()
                .Select(c => new { c.Id, c.Cost }).ToDictionaryAsync(item => item.Id, item => item.Cost);


            var purchase = lineItems
                .Select(c => new LineItemEntity { 
                    BeverageSizeCostId = c.BeverageSizeCostId,
                    Count = c.Count,
                    CostPerItem = costPerItem[c.BeverageSizeCostId]
                });
            
            var invoice = new InvoiceEntity { Date = DateTime.Now, LineItems = purchase.ToArray()};

            localDbContext.Invoice.Add(invoice);

            await localDbContext.SaveChangesAsync();

            return ToModel(invoice);
        }

        public async Task UpsertBeverageSizeCostAsync(BeverageSizeCostModel price)
        {
          //update price

            
                
            if (price.Id > 0)
            {
                var beveragePrice = await localDbContext.BeverageCost
                    .Where(c => c.Id == price.Id)
                    .Include(d => d.Beverage)
                    .SingleAsync();

                beveragePrice.Beverage.Name = price.Beverage.Name;
                beveragePrice.Cost = price.Cost;
                beveragePrice.Beverage.IsActive = price.Beverage.IsActive;
                beveragePrice.BeverageSizeId = price.BeverageSizeId;

                await localDbContext.SaveChangesAsync();

                return;
            }


            if(price.BeverageId == 0)
            {
                await localDbContext.BeverageCost.AddAsync(ToEntity(price));

                localDbContext.SaveChanges();

                return;
            }

            var isBeverageAvailable = await localDbContext.BeverageCost.AsNoTracking()
                .Where(c => c.BeverageId == price.BeverageId)
                .AnyAsync();

            if(isBeverageAvailable)
            {
                price.Beverage = null;

                await localDbContext.BeverageCost.AddAsync(ToEntity(price));

                await localDbContext.SaveChangesAsync();

                return;
            }

            return;

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

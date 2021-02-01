﻿using AutoMapper;
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

        public async Task<BeverageSizeCostModel> UpsertBeverageSizeCostAsync(BeverageSizeCostModel price)
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

                return ToModel(beveragePrice);
            }


            if(price.BeverageId == 0)
            {
                await localDbContext.BeverageCost.AddAsync(ToEntity(price));

                localDbContext.SaveChanges();

                return price;
            }

            var isBeverageAvailable = await localDbContext.BeverageCost.AsNoTracking()
                .Where(c => c.BeverageId == price.BeverageId)
                .AnyAsync();

            if(isBeverageAvailable)
            {
                price.Beverage = null;

                await localDbContext.BeverageCost.AddAsync(ToEntity(price));

                await localDbContext.SaveChangesAsync();

                return price;
            }

            throw new CommandExceptions();

        }

        public async Task<InvoiceModel> UpsertCustomerPurchaseAsync(InvoiceModel invoice)
        {
            var isPhoneNumberFound = await localDbContext.Users.AsNoTracking()
                .Where(c => c.PhoneNumber == invoice.User.PhoneNumber)
                .AnyAsync();

            if(isPhoneNumberFound)
            {
                var pointsQuery = await localDbContext.Users
                    .Where(c => c.PhoneNumber == invoice.User.PhoneNumber)
                    .SingleAsync();

                pointsQuery.Points += invoice.User.Points;

                invoice.UserId = pointsQuery.Id;

                await localDbContext.SaveChangesAsync();

                invoice.User = null;

                var costPerItem = await localDbContext.BeverageCost.AsNoTracking()
                .Select(c => new { c.Id, c.Cost }).ToDictionaryAsync(item => item.Id, item => item.Cost);

                var sizeCostIds = invoice.LineItems
                    .Select(c => new LineItemModel
                    { 
                        BeverageSizeCostId = c.BeverageSizeCostId,
                        Count = c.Count,
                        CostPerItem = costPerItem[c.BeverageSizeCostId]
                    })
                    .ToArray();

                invoice.LineItems = sizeCostIds.ToArray();

                await localDbContext.AddAsync(ToEntity(invoice));

                await localDbContext.SaveChangesAsync();

                return invoice;
            }
            else
            {
                var costPerItem = await localDbContext.BeverageCost.AsNoTracking()
                    .Select(c => new { c.Id, c.Cost }).ToDictionaryAsync(item => item.Id, item => item.Cost);

                var sizeCostIds = invoice.LineItems
                    .Select(c => new LineItemModel
                    {
                        BeverageSizeCostId = c.BeverageSizeCostId,
                        Count = c.Count,
                        CostPerItem = costPerItem[c.BeverageSizeCostId]
                    })
                    .ToArray();

                invoice.LineItems = sizeCostIds.ToArray();

                invoice.Date = DateTime.Now;

                await localDbContext.AddAsync(ToEntity(invoice));

                await localDbContext.SaveChangesAsync();

                return invoice;
            }

        }

        public async Task<InvoiceModel> PurchaseRedeemPointsAsync(InvoiceModel invoice)
        {
            var user = await localDbContext.Users
                .Where(c => c.Id == invoice.User.Id)
                .SingleAsync();

            var lineItems = invoice.LineItems;

            var count = lineItems
                .Select(c => c.Count)
                .Single();

            if (user.Points >= count * invoice.User.Points)
            {
                user.Points -= count * invoice.User.Points;

                var entityItems = lineItems.Select(ToEntity).ToList();

                var newInvoice = new InvoiceEntity
                    {
                        Date = DateTime.Now,
                        LineItems = entityItems,
                        UserId = user.Id
                    };

                await localDbContext.AddAsync(newInvoice);

                await localDbContext.SaveChangesAsync();

                return ToModel(newInvoice);
            }
            else
            {
                throw new InvalidOperationException("Insufficient points");
            }

            throw new InvalidOperationException("Error logic");

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
        private UserModel ToModel(UserEntity entity) => mapper.Map<UserModel>(entity);

        private UserEntity ToEntity(UserModel model) => mapper.Map<UserEntity>(model);
        //-----------------------------------------------------------------------------------------

    }
}

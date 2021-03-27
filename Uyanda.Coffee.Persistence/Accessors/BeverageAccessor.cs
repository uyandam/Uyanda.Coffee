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

        public async Task<InvoiceModel> SimplePurchaseAsync(int customerId, IEnumerable<LineItemModel> lineItems,  decimal cost, decimal exchangeRate, string Currency)
        {
            if(customerId == 1)
            {
                var beveragePrices = await localDbContext.BeverageCost.AsNoTracking()
                     .Select(c => new
                     {
                         c.Id,
                         c.Cost
                     })
                     .ToDictionaryAsync(item => item.Id, item => item.Cost);

                var purchase = lineItems
                .Select(c => new LineItemModel
                {
                    BeverageSizeCostId = c.BeverageSizeCostId,
                    Count = c.Count,
                    CostPerItem = beveragePrices[c.BeverageSizeCostId]
                }).ToList();

                var currencyUsed = lineItems
                .Select(c => new CurrencyModel
                {
                    BeverageSizeCostId = c.BeverageSizeCostId,
                    CurrencyCostPerItem = beveragePrices[c.BeverageSizeCostId] * exchangeRate
                }).ToList();

                var customerInvoice = new InvoiceModel
                {
                    Date = DateTime.Now,
                    LineItems = purchase,
                    Currencies = currencyUsed,
                    CustomerId = 1,
                    IsRedeemingPoints = false,
                    DiscountedPoints = 0,
                    FinalInvoicePrice = cost,
                    CurrencyFinalIncoicePrice = cost * exchangeRate,
                    CurrencyCode = Currency
                };

                await localDbContext.AddAsync(ToEntity(customerInvoice));

                await localDbContext.SaveChangesAsync();

                return customerInvoice;

            }


            if(customerId > 1)
            {

                var beveragePrices = await localDbContext.BeverageCost.AsNoTracking()
                     .Select(c => new
                     {
                         c.Id,
                         c.Cost
                     })
                     .ToDictionaryAsync(item => item.Id, item => item.Cost);

                var purchase = lineItems
                .Select(c => new LineItemModel
                {
                    BeverageSizeCostId = c.BeverageSizeCostId,
                    Count = c.Count,
                    CostPerItem = beveragePrices[c.BeverageSizeCostId]
                }).ToList();

                var currencyUsed = lineItems
                .Select(c => new CurrencyModel
                {
                    BeverageSizeCostId = c.BeverageSizeCostId,
                    CurrencyCostPerItem = beveragePrices[c.BeverageSizeCostId] * exchangeRate
                }).ToList();

                var customerInvoice = new InvoiceModel
                {
                    Date = DateTime.Now,
                    LineItems = purchase,
                    Currencies = currencyUsed,
                    CustomerId = customerId,
                    IsRedeemingPoints = false,
                    DiscountedPoints = 0,
                    FinalInvoicePrice = cost,
                    CurrencyFinalIncoicePrice = cost * exchangeRate,
                    CurrencyCode = Currency
                };

                await localDbContext.AddAsync(ToEntity(customerInvoice));

                await localDbContext.SaveChangesAsync();

                return customerInvoice;
            }

            throw new InvalidOperationException("invalid customer ID");
        }

        public async Task<InvoiceModel> DiscountPurchaseAsync(int customerId, IEnumerable<LineItemModel> lineItems, decimal points, decimal cost, decimal exchangeRate, string Currency)
        {
            if (customerId < 2)
                throw new InvalidOperationException("invalid customer ID");

            var beveragePrices = await localDbContext.BeverageCost.AsNoTracking()
                    .Select(c => new
                    {
                        c.Id,
                        c.Cost
                    })
                    .ToDictionaryAsync(item => item.Id, item => item.Cost);

            var purchase = lineItems
            .Select(c => new LineItemModel
            {
                BeverageSizeCostId = c.BeverageSizeCostId,
                Count = c.Count,
                CostPerItem = beveragePrices[c.BeverageSizeCostId]
            }).ToList();

            var currencyUsed = lineItems
            .Select(c => new CurrencyModel
            {
                BeverageSizeCostId = c.BeverageSizeCostId,
                CurrencyCostPerItem = beveragePrices[c.BeverageSizeCostId] * exchangeRate
            }).ToList();

            var customerInvoice = new InvoiceModel
            {
                Date = DateTime.Now,
                LineItems = purchase,
                Currencies = currencyUsed,
                CustomerId = customerId,
                IsRedeemingPoints = false,
                DiscountedPoints = points,
                FinalInvoicePrice = cost,
                CurrencyFinalIncoicePrice = cost * exchangeRate,
                CurrencyCode = Currency
            };

            await localDbContext.AddAsync(ToEntity(customerInvoice));

            await localDbContext.SaveChangesAsync();

            return customerInvoice;

        }

        public async Task<CustomerModel> AddCustomerAsync(CustomerModel customer)
        {
            var isCustomerFound = await localDbContext.Customer.AsNoTracking()
                .Where(c => c.PhoneNumber == customer.PhoneNumber)
                .AnyAsync();

            if (isCustomerFound)
                throw new InvalidOperationException("Phone number already exists");

            await localDbContext.AddAsync(ToEntity(customer));

            await localDbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<CustomerModel> GetCustomerAsync(CustomerModel customer)
        {
            var result =  await localDbContext.Customer.AsNoTracking()
                .Where(c => c.Id == customer.Id)
                .SingleAsync();

            return ToModel(result);
        }

        public async Task<CustomerModel> GetCustomerIdAsync(CustomerModel customer)
        {
            var result = await localDbContext.Customer.AsNoTracking()
                .Where(c => c.PhoneNumber == customer.PhoneNumber)
                .Select(d => d.Id)
                .SingleOrDefaultAsync();

            customer.Id = result;

            return customer;
        }


        public async Task<IDictionary<int, decimal>> BeveragePricesAync()
        {
            return await localDbContext.BeverageCost.AsNoTracking()
                .Select(c => new { c.Id, c.Cost })
                .ToDictionaryAsync(item => item.Id, item => item.Cost);
        }

        public async Task<bool> DoesCustomerExistAsync(CustomerModel customer)
        {
            var isCustomerFound = await localDbContext.Customer.AsNoTracking()
                .Where(c => customer.Id == c.Id)
                .AnyAsync();

            return isCustomerFound;
        }

        public async Task UpdateCustomerPointsAsync(int customerId, decimal points)
        {
            var customer = await localDbContext.Customer
                .Where(c => c.Id == customerId)
                .SingleAsync();

            customer.Points = points;

            await localDbContext.SaveChangesAsync();

        }

        //-----------------------------------------------------------------------------------------
        private CurrencyModel TodModel(CurrencyEntity entity) => mapper.Map<CurrencyModel>(entity);

        private CurrencyEntity ToEntity(CurrencyModel model) => mapper.Map<CurrencyEntity>(model);

        //-----------------------------------------------------------------------------------------

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
        private CustomerModel ToModel(CustomerEntity entity) => mapper.Map<CustomerModel>(entity);

        private CustomerEntity ToEntity(CustomerModel model) => mapper.Map<CustomerEntity>(model);
        //-----------------------------------------------------------------------------------------
        private PayModel ToModel(PayEntity entity) => mapper.Map<PayModel>(entity);

        private PayEntity ToEntity(PayModel model) => mapper.Map<PayEntity>(model);
        //-----------------------------------------------------------------------------------------

    }
}

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


        public async Task<InvoiceModel> PurchaseAsync(IEnumerable<LineItemModel> lineItems, CustomerModel customer, bool IsRedeemingPoints)
        {
            /*
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
            */


            /*if IsRedeemingPoints == false && CustomerId == 0
             *  return NormalPurchase() 
             *  
             * if IsRedeemingPoints == false && CustomerId > 0
             *  return NormalPurchase() && AddCustomerPoints()
             * 
             * if IsRedeemingPoints == true && CustomerId > 0
             *  return NormalPurchase() && RedeemCustomerPoints()
             * 
             * 
             */

            if (IsRedeemingPoints == false)
            {
                return await NormalPurchaseAsync(lineItems, customer);
            }

            if(IsRedeemingPoints)
            {
                return await DiscountPurchaseAsync(lineItems, customer);
            }

            throw new InvalidOperationException("Invalid input");


        }


        private async Task<InvoiceModel> NormalPurchaseAsync(IEnumerable<LineItemModel> lineItems, CustomerModel customer)
        {
            var beveragePrices = await localDbContext.BeverageCost.AsNoTracking()
                .Select(c => new { c.Id, c.Cost })
                .ToDictionaryAsync(item => item.Id, item => item.Cost);

            var totalCost = lineItems
                .Sum(c => c.Count * beveragePrices[c.BeverageSizeCostId]);

            int discount = 10;

            var earnedPoints = totalCost / discount;

            var isUserFound = await localDbContext.Customer
                    .Where(c => c.Id == customer.Id)
                    .AnyAsync();

            var costPerItem = await localDbContext.BeverageCost.AsNoTracking()
                .Select(c => new { c.Id, c.Cost }).ToDictionaryAsync(item => item.Id, item => item.Cost);

            var purchase = lineItems
                .Select(c => new LineItemModel
                {
                    BeverageSizeCostId = c.BeverageSizeCostId,
                    Count = c.Count,
                    CostPerItem = costPerItem[c.BeverageSizeCostId]
                }).ToList();

            if (!isUserFound)
            {
                if (customer.Id != 0)
                    throw new InvalidOperationException("Invalid Id value");

                var customerInvoice = new InvoiceModel
                { 
                    Date = DateTime.Now,
                    LineItems = purchase,
                    CustomerId = 1
                };

                await localDbContext.AddAsync(ToEntity(customerInvoice));

                await localDbContext.SaveChangesAsync();

                return customerInvoice;
            }        

            if (isUserFound)
            {
                if (customer.Id == 1)
                    throw new InvalidOperationException("invalid ID");

                customer.Points += earnedPoints;

                await localDbContext.AddAsync(ToEntity(customer));

                await localDbContext.SaveChangesAsync();

                var customerInvoice = new InvoiceModel
                {
                    Date = DateTime.Now,
                    LineItems = purchase,
                    CustomerId = customer.Id
                };

                await localDbContext.AddAsync(ToEntity(customerInvoice));

                await localDbContext.SaveChangesAsync();

                return customerInvoice;
            }

            throw new InvalidOperationException("Invalid input");

        }

        private async Task<InvoiceModel> DiscountPurchaseAsync(IEnumerable<LineItemModel> lineItems, CustomerModel customer)
        {
            var isUserFound = await localDbContext.Customer
                .Where(c => c.Id == customer.Id)
                .AnyAsync();

            if (isUserFound == false)
                throw new InvalidOperationException("Phone number does not exist");

            var beveragePrices = await localDbContext.BeverageCost.AsNoTracking()
                .Select(c => new { c.Id, c.Cost })
                .ToDictionaryAsync(item => item.Id, item => item.Cost);

            var totalCost = lineItems
                .Sum(c => c.Count * beveragePrices[c.Id]);

            var customerEntity = await localDbContext.Customer
                .Where(c => c.Id == customer.Id)
                .SingleAsync();

            var discount = customerEntity.Points;

            totalCost -= discount;

            if (totalCost < 0)
            {
                discount = - totalCost;

                totalCost = 0;
            }
            else
            {
                discount = 0;
            }

            customerEntity.Points = discount;

            await localDbContext.SaveChangesAsync();

            var beverageCost = new InvoiceEntity
            {
                Date = DateTime.Now,
                LineItems = lineItems.Select(ToEntity).ToList(),
                CustomerId = customer.Id
            };

            await localDbContext.AddAsync(beverageCost);

            await localDbContext.SaveChangesAsync();

            return ToModel(beverageCost);
            
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

        public async Task<CustomerModel> GetCustomerIdAsync(CustomerModel customer)
        {
            var result =  await localDbContext.Customer.AsNoTracking()
                .Where(c => c.PhoneNumber == customer.PhoneNumber)
                .SingleAsync();

            return ToModel(result);
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
        private CustomerModel ToModel(CustomerEntity entity) => mapper.Map<CustomerModel>(entity);

        private CustomerEntity ToEntity(CustomerModel model) => mapper.Map<CustomerEntity>(model);
        //-----------------------------------------------------------------------------------------

    }
}

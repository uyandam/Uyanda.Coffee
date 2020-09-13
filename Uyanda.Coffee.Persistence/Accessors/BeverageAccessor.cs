using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;
using Uyanda.Coffee.Application.Features.BeverageManagement.Persistence;
using Uyanda.Coffee.Persistence.Entities;

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
            
            //Console.WriteLine(beverages.First());
            var requestedCoffee = beverages.First().Id;
            var dbQuery = from b in localDbContext.Beverages.AsNoTracking()
                          where b.Id == requestedCoffee
                          // Read on Linq (How to use the where clause.). Read on both Query type and Method type
                          select b;

            var entities = await dbQuery.ToArrayAsync();

            return entities.Select(ToModel);
        }

        private BeverageModel ToModel(BeverageEntity entity) => mapper.Map<BeverageModel>(entity);

        private BeverageEntity ToEntity(BeverageModel model) => mapper.Map<BeverageEntity>(model);
    }
}

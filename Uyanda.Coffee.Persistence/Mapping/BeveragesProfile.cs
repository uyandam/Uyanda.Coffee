using AutoMapper;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;
using Uyanda.Coffee.Persistence.Entities;

namespace Uyanda.Coffee.Persistence.Mapping
{
    public class BeveragesProfile : Profile
    {
        public BeveragesProfile()
        {
            CreateMap<BeverageModel, BeverageEntity>();
            CreateMap<BeverageEntity, BeverageModel>();

            CreateMap<BeverageSizeCostModel, BeverageSizeCostEntity>();
            CreateMap<BeverageSizeCostEntity, BeverageSizeCostModel>();
        }
    }
}

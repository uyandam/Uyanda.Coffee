using AutoMapper;
using Uyanda.Coffee.Application.Features.BeverageManagement.Models;
using Uyanda.Coffee.Persistence.Entities;

namespace Uyanda.Coffee.Persistence.Mapping
{
    public class BeveragesProfile : Profile
    {
        public BeveragesProfile()
        {
            //Beverage Mapping
            CreateMap<BeverageModel, BeverageEntity>();
            CreateMap<BeverageEntity, BeverageModel>();

            //BeverageSize Mapping
            CreateMap<BeverageSizeModel, BeverageSizeEntity>();
            CreateMap<BeverageSizeEntity, BeverageSizeModel>();

            //BeverageType Mapping
            CreateMap<BeverageTypeModel, BeverageTypeEntity>();
            CreateMap<BeverageTypeEntity, BeverageTypeModel>();
        }
    }
}

using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Models.Products;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();

            CreateMap<MstProduct, MstProductModel>();

            CreateMap<MstManufacture, MstManufactureModel>();

            CreateMap<MstKbn, MstKbnModel>();

            CreateMap<MstDisasterStock, MstDisasterStockModel>();
        }
    }
}
using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Models.Products;
using WebApi.Models.Manufactures;
using WebApi.Models.Prefs;
using WebApi.Models.Branches;
using WebApi.Models.Kbns;
using WebApi.Models.DisasterStocks;

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
            CreateMap<MstPref, MstPrefModel>();
            CreateMap<MstBranch, MstBranchModel>();

            CreateMap<MstKbn, MstKbnModel>();

            CreateMap<MstDisasterStock, MstDisasterStockModel>();
            CreateMap<MstDisasterStockModel, MstDisasterStock>();
        }
    }
}